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
            // Get our subset into a array so we can refer to items by index and so we're not iterating it multiple times.
            var SubsetArray = subset.ToArray();
            // The position of the subset array we will check
            var SubsetArrayPos = 0;
            // A list to hold current items in the subsequence, ready to be included in the resulting sequence
            var CurrentList = new List<T>();
            foreach (var item in sequence)
            {
                // add all items (ones part of the subset will be removed)
                CurrentList.Add(item);
                if (item.Equals(SubsetArray[SubsetArrayPos]))
                {
                    // This item is part of the subset array, so move to the next subset position
                    SubsetArrayPos++;
                    // Check whether we've checked all subset positions
                    if (SubsetArrayPos == SubsetArray.Length)
                    {
                        // If so, then remove the subset items from the current list
                        CurrentList.RemoveRange(CurrentList.Count - SubsetArray.Length, SubsetArray.Length);
                        // Reset the position
                        SubsetArrayPos = 0;
                        // Only return the list if it's not empty (the main list could start with a subset)
                        if (CurrentList.Count != 0)
                        {
                            // Return the list we have now since it's been ended.
                            yield return CurrentList;
                            // Create a new list ready for more items
                            CurrentList = new List<T>();
                        }
                    }
                }
                else
                {
                    // This item isn't part of the subset, so next time check the start.
                    SubsetArrayPos = 0;
                }
            }
            // If we get to the end and have some items to return, then return them.
            if (CurrentList.Count != 0)
                yield return CurrentList;
        }
    }
