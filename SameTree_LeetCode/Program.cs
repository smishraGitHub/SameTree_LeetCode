using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameTree_LeetCode
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int data)
        {
            val = data;
            left = null;
            right = null;
        }
    }

    class Program
    {
        TreeNode node;

        static void inorder(TreeNode node)
        {
            if (node == null)
                return;
            inorder(node.left);
            Console.Write(node.val + " ");
            inorder(node.right);
        }


        static void insert(TreeNode node, int key)
        {
            if (node == null)
                return;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);

            while (q.Count != 0)
            {
                node = q.Peek();
                q.Dequeue();

                if (node.left == null)
                {
                    node.left = new TreeNode(key);
                    break;

                }
                else
                    q.Enqueue(node.left);

                if (node.right == null)
                {
                    node.right = new TreeNode(key);
                    break;
                }
                else
                    q.Enqueue(node.right);
            }

        }


        static bool checkBothTreeAreSameOrNot(TreeNode t1, TreeNode t2)
        {

            if (t1 == null && t2 == null)
                return true;
            else if ((t1 == null && t2 != null) || (t1 != null && t2 == null))
                return false;
            else
            {
                if (t1.val != t2.val)
                    return false;
                else
                    return checkBothTreeAreSameOrNot(t1.left, t2.left) && checkBothTreeAreSameOrNot(t1.right, t2.right);

            }
        }

        static bool isMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if (t1 == null || t2 == null)
                return false;

            return (t1.val == t2.val)&& isMirror(t1.left, t2.right) && isMirror(t1.right, t2.left);
        }

        static int MaximumDepthOfBinaryTree(TreeNode t1)
        {
            if (t1 == null)
                return 0;

            int left = MaximumDepthOfBinaryTree(t1.left);
            int right = MaximumDepthOfBinaryTree(t1.right);

            if (left > right)
                return left+1;
            else
                return right+1;
           
        }

        static void Main(string[] args)
        {
            TreeNode root = null;
            root = new TreeNode(1);
            root.left = new TreeNode(4);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(5);

            Console.WriteLine("First Tree");

            inorder(root);


            TreeNode root1 = null;
            root1 = new TreeNode(1);
            root1.left = new TreeNode(2);
            root1.right = new TreeNode(3);
            Console.WriteLine("");
            Console.WriteLine("Second Tree");

            inorder(root1);
            Console.WriteLine("");
            Console.WriteLine("Check Both tree are same or not");
            Console.WriteLine(checkBothTreeAreSameOrNot(root, root1));

            Console.WriteLine("");
            Console.WriteLine("Depth of First tree");
            Console.WriteLine(MaximumDepthOfBinaryTree(root));

            Console.WriteLine("");
            Console.WriteLine("Depth of Second tree");
            Console.WriteLine(MaximumDepthOfBinaryTree(root1));

            Console.ReadLine();

        }
    }
}
