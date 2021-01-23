    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            byte[] exampleArray = new byte[] { 1, 2, 3, 4, 5, 2, 3, 6, 7, 8 };
            var test = exampleArray.PartitionBySubset(new byte[] { 2, 3 }).ToList();
        }
    }
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> PartitionBySubset<T>(this IEnumerable<T> sequence, IEnumerable<T> subset) where T : IEquatable<T>
        {
            var SubsetArray = subset.ToArray();
            var SubsetArrayPos = 0;
            var CurrentList = new List<T>();
            foreach (var item in sequence)
            {
                CurrentList.Add(item);
                if (item.Equals(SubsetArray[SubsetArrayPos]))
                {
                    SubsetArrayPos++;
                    if (SubsetArrayPos == SubsetArray.Length)
                    {
                        CurrentList.RemoveRange(CurrentList.Count - SubsetArray.Length, SubsetArray.Length);
                        SubsetArrayPos = 0;
                        yield return CurrentList;
                        CurrentList = new List<T>();
                    }
                }
                else
                {
                    SubsetArrayPos = 0;
                }
            }
            if (CurrentList.Count != 0)
                yield return CurrentList;
        }
    }
