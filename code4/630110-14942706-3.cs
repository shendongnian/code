        using System;
        using System.Collections.Generic;
        namespace Demo
        {
            public static class Program
            {
                private static void Main(string[] args)
                {
                    var d1 = new Dictionary<int, int> {{1, 1}, {2, 2}, {3, 3}, {4, 4}};
                    var iter = d1.GetEnumerator();
                    if (iter.MoveNext())
                    {
                        var previous = iter.Current;
                        while (iter.MoveNext())
                        {
                            // You have current and previous available now.
                            Console.WriteLine("Current = " + iter.Current.Value + ", previous = " + previous.Value);
                            previous = iter.Current;
                        }
                    }
                }
            }
        }
