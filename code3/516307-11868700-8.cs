    using System;
    using System.Collections.Generic;
    public class Program {
        class Node {
            public int Data;
            public IEnumerable<Node> Dependents { get; set; }
        }
        public static void Main() {
            var root = Create(
                10
            ,   Create(5, Create(3), Create(7, Create(6), Create(8)))
            ,   Create(20, Create(15), Create(30, Create(28), Create(40)))
            );
            // We cannot combine the declaration and definition here
            Func<Node,IEnumerable<Node>> all = null;
            // The recursive magic is in the following line
            all = n => n.Dependents.SelectMany(d => all(d)).Concat(new[] {n});
            // Here is how you can use it
            foreach (var node in all(root)) {
                Console.WriteLine(node.Data);
            }
        }
        // Helper function for creating tree nodes
        private static Node Create(int data, params Node[] nodes) {
            return new Node { Data = data, Dependents = nodes };
        }
    }
