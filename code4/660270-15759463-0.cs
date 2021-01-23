    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Program
        {
            [STAThread]
            private static void Main(string[] args)
            {
                var hashSet = new HashSet<int> {4, 0, 6, -1, 23, -8, 14, 12, -9, 5, 2};
                var itemProcessor = new ItemProcessor();
                hashSet.RemoveWhere(itemProcessor.Process);
                Console.WriteLine("Max = {0}, Min = {1}", itemProcessor.Max, itemProcessor.Min);
                Console.WriteLine("\nHashSet contents:");
                foreach (int number in hashSet)
                {
                    Console.WriteLine(number);
                }
            }
        }
        public sealed class ItemProcessor
        {
            private int max = int.MinValue;
            private int min = int.MaxValue;
            // Removes all negative numbers and calculates max and min values.
            public bool Process(int item)
            {
                max = Math.Max(item, max);
                min = Math.Min(item, min);
                return (item < 0);
            }
            public int Max { get { return max; } }
            public int Min { get { return min; } }
        }
    }
