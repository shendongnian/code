    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                var tree = buildTree(5, true);
                printTree1(tree);
                Console.WriteLine("---------------------------------------------");
                printTree2(tree);
            }
            // Print tree using direct recursion.
            static void printTree1<T>(Node<T> tree)
            {
                if (tree != null)
                {
                    Console.WriteLine(tree.Value);
                    printTree1(tree.Left);
                    printTree1(tree.Right);
                }
            }
            // Print tree using flattened tree.
            static void printTree2<T>(Node<T> tree)
            {
                foreach (var value in flatten(tree))
                {
                    Console.WriteLine(value);
                }
            }
            // Flatten tree using recursion.
            static IEnumerable<T> flatten<T>(Node<T> root)
            {
                if (root == null)
                {
                    yield break;
                }
                foreach (var node in flatten(root.Left))
                {
                    yield return node;
                }
                foreach (var node in flatten(root.Right))
                {
                    yield return node;
                }
                yield return root.Value;
            }
            static Node<string> buildTree(int depth, bool left)
            {
                if (depth > 0)
                {
                    --depth;
                    return new Node<string>(buildTree(depth, true), buildTree(depth, false), "Node." + depth + (left ? ".L" : ".R"));
                }
                else
                {
                    return new Node<string>(null, null, "Leaf." + (left ? "L" : "R"));
                }
            }
        }
        public sealed class Node<T>
        {
            public Node(Node<T> left, Node<T> right, T value)
            {
                _left  = left;
                _right = right;
                _value = value;
            }
            public Node<T> Left  { get { return _left;  } }
            public Node<T> Right { get { return _right; } }
            public T       Value { get { return _value; } }
            private readonly Node<T> _left;
            private readonly Node<T> _right;
            private readonly T       _value;
        }
    }
