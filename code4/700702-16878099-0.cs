    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace Demo
    {
        sealed class Node<T>
        {
            public T Data;  // Payload.
            public Node<T> Next;  // This will point to the next sibling node (if any), forming a linked-list.
            public Node<T> Child; // This will point to the first child node (if any).
        }
        sealed class Tree<T>: IEnumerable<T>
        {
            public Node<T> Root;
            public Node<T> AddChild(Node<T> parent, T data)
            {
                parent.Child = new Node<T>
                {
                    Data = data,
                    Next = parent.Child // Prepare to place the new node at the head of the linked-list of children.
                };
                return parent.Child;
            }
            public IEnumerator<T> GetEnumerator()
            {
                return enumerate(Root).GetEnumerator();
            }
            private IEnumerable<T> enumerate(Node<T> root)
            {
                for (var node = root; node != null; node = node.Next)
                {
                    yield return node.Data;
                    foreach (var data in enumerate(node.Child))
                        yield return data;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        class Program
        {
            void run()
            {
                var tree = new Tree<string>();
                tree.Root = new Node<string>{Data = "Root"};
                var l1n3 = tree.AddChild(tree.Root, "L1 N3");
                var l1n2 = tree.AddChild(tree.Root, "L1 N2");
                var l1n1 = tree.AddChild(tree.Root, "L1 N1");
                tree.AddChild(l1n1, "L2 N1 C3");
                tree.AddChild(l1n1, "L2 N1 C2");
                var l2n1 = tree.AddChild(l1n1, "L2 N1 C1");
                tree.AddChild(l1n2, "L2 N2 C3");
                tree.AddChild(l1n2, "L2 N2 C2");
                tree.AddChild(l1n2, "L2 N2 C1");
                tree.AddChild(l1n3, "L2 N3 C3");
                tree.AddChild(l1n3, "L2 N3 C2");
                tree.AddChild(l1n3, "L2 N3 C1");
                tree.AddChild(l2n1, "L3 N1 C3");
                tree.AddChild(l2n1, "L3 N1 C2");
                tree.AddChild(l2n1, "L3 N1 C1");
                tree.Print();
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self)
                    Console.WriteLine(item);
            }
        }
    }
                                                                              
