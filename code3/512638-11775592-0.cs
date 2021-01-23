    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                int count = 85160;
                var someNumbers = Enumerable.Range(0, count).ToList();
                var lists = PartitionToEqualSizedLists(someNumbers, 3);
                foreach (var list in lists)
                {
                    Console.WriteLine("List length = " + list.Count);
                }
                Console.WriteLine("\nDone.");
                Console.ReadLine();
            }
            public static List<List<T>> PartitionToEqualSizedLists<T>(List<T> input, int numPartitions)
            {
                int blockSize = (input.Count + numPartitions - 1)/numPartitions;
                return input.Partition(blockSize).Select(partition => partition.ToList()).ToList();
            }
        }
        public static class EnumerableExt
        {
            public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> input, int blockSize)
            {
                var enumerator = input.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return nextPartition(enumerator, blockSize);
                }
            }
            private static IEnumerable<T> nextPartition<T>(IEnumerator<T> enumerator, int blockSize)
            {
                do
                {
                    yield return enumerator.Current;
                }
                while (--blockSize > 0 && enumerator.MoveNext());
            }
        }
    }
