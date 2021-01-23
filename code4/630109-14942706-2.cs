    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                var d1 = new Dictionary<int, int> {{1, 1}, {2, 2}, {3, 3}, {4, 4}};
                bool isFirst = true;
                var previous = new KeyValuePair<int, int>();
                foreach (var current in d1)
                {
                    if (!isFirst)
                    {
                        // You have current and previous available now.
                        Console.WriteLine("Current = " + current.Value + ", previous = " + previous.Value);
                    }
                    previous = current;
                    isFirst = false;
                }
            }
        }
    }
