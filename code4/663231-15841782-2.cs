    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    public static class MoreExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>
            (this IEnumerable<T> source, T separator)
        {
            List<T> currentList = new List<T>();
            var comparer = EqualityComparer<T>.Default;
            foreach (var item in source)
            {
                if (comparer.Equals(item, separator))
                {
                    yield return new ReadOnlyCollection<T>(currentList);
                    currentList = new List<T>();
                }
                else
                {
                    currentList.Add(item);
                }
            }
            yield return new ReadOnlyCollection<T>(currentList);
        }
    
    }
    
    class Test
    {
        static void Main()
        {
            int[] source = { 0, 1, 2, 0, 0, 2, 3, 0, 4, 5, 6 };
            foreach (var group in source.Split(0).Where(x => x.Any()))
            {
                Console.WriteLine("[{0}]", string.Join(",", group));
            }
        }    
    }
