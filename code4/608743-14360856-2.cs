    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace Demo
    {
        internal class Program
        {
            private LL myList = new LL();
            private static void Main()
            {
                var gogo = new Program();
            }
            public Program()
            {
                myList.Add("test");
                myList.Add("test1");
                foreach (var item in myList) // This now works.
                    Console.WriteLine(item);
                Console.Read();
            }
        }
        internal class LL: IEnumerable<string>
        {
            private LLNode first;
            public void Add(string s)
            {
                if (this.first == null)
                    this.first = new LLNode
                    {
                        Value = s
                    };
                else
                {
                    var node = this.first;
                    while (node.Next != null)
                        node = node.Next;
                    node.Next = new LLNode
                    {
                        Value = s
                    };
                }
            }
            public IEnumerator<string> GetEnumerator()
            {
                for (var node = first; node != null; node = node.Next)
                {
                    yield return node.Value;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            private class LLNode
            {
                public string Value { get; set; }
                public LLNode Next { get; set; }
            }
        }
    }
