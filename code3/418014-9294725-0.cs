    using System;
    using System.Collections.Generic;
    namespace TreeTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Build example tree
                Tree tree = new Tree();
                Node a = new Node(2);
                Node b = new Node(7);
                Node c = new Node(2);
                Node d = new Node(6);
                Node e = new Node(5);
                Node f = new Node(11);
                Node g = new Node(5);
                Node h = new Node(9);
                Node i = new Node(4);
    
                tree.rootNode = a;
                a.Edges.Add(b);
                b.Edges.Add(c);
                b.Edges.Add(d);
                d.Edges.Add(e);
                d.Edges.Add(f);
                a.Edges.Add(g);
                g.Edges.Add(h);
                h.Edges.Add(i);
    
                //Find node scannin tree from top down
                Node node = tree.FindByValueBreadthFirst(6);
                Console.WriteLine(node != null ? "Found node" : "Did not find node");
    
                //Find node scanning tree branch for branch.
                node = tree.FindByValueDepthFirst(2);
                Console.WriteLine(node != null ? "Found node" : "Did not find node");
    
                Console.WriteLine("PRESS ANY KEY TO EXIT");
                Console.ReadKey();
            }
        }
        class Tree
        {
            public Node rootNode;
            public Node FindByValueDepthFirst(int val)
            {
                return rootNode.FindRecursiveDepthFirst(val);
            }
            public Node FindByValueBreadthFirst(int val)
            {
                if (rootNode.Value == val)
                    return rootNode;
                else
                    return rootNode.FindRecursiveBreadthFirst(val);
            }
        }
        class Node
        {
            public int Value { get; set; }
            public IList<Node> Edges { get; set; }
            public Node(int val)
            {
                Value = val;
                Edges = new List<Node>(2);
            }
            public Node FindRecursiveBreadthFirst(int val)
            {
                foreach (Node node in Edges)
                {
                    if (node.Value == val)
                        return node;
                }
                foreach (Node node in Edges)
                {
                    Node result = node.FindRecursiveBreadthFirst(val);
                    if (result != null)
                        return result;
                }
                return null;
            }
            public Node FindRecursiveDepthFirst(int val)
            {
                if (Value == val)
                    return this;
                else
                {
                    foreach (Node node in Edges)
                    {
                        Node result = node.FindRecursiveDepthFirst(val);
                        if (result != null)
                            return result;
                    }
                    return null;
                }
            }
        }
    }
