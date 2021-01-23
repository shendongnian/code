    using System;
    using System.Collections;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            foreach (var i in list)
            { // this IS NOT using IEnumerable/IEnumerable<T>
                Console.WriteLine(i);
            }
        }
    }
    public class MyList<T> : IEnumerable<T>
    {
        internal sealed class Node
        {
            private readonly T value;
            public Node Next { get; set; }
            public T Value { get { return value; } }
            public Node(T value) { this.value = value; }
        }
        Node root;
        public void Add(T value)
        {
            var newNode = new Node(value);
            var node = root;
            if (node == null) root = newNode;
            else
            {
                while (node.Next != null) node = node.Next;
                node.Next = newNode;
            }
        }
        public Enumerator GetEnumerator() { return new Enumerator(this); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() { return GetEnumerator(); }
        public struct Enumerator : IEnumerator, IEnumerator<T>
        {
            void IDisposable.Dispose() { node = null; list = null; }
            void IEnumerator.Reset() { node = null; }
            object IEnumerator.Current { get { return Current; } }
            private MyList<T> list;
            private Node node;
            public bool MoveNext()
            {
                if (node == null)
                {
                    node = list.root;
                    return node != null;
                }
                else
                {
                    if (node.Next == null) return false;
                    node = node.Next;
                    return node != null;
                }
            }
            internal Enumerator(MyList<T> list) { this.list = list; node = null; }
            public T Current { get { return node == null ? default(T) : node.Value; } }
        }
    }
