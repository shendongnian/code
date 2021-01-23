    var max4 = new int[][] { arr1, arr2, arr3, arr4 }
                .Max(new SOExtensions.Comparer<int>())
                .ToArray();
    public static class SOExtensions
    {
        public static IEnumerable<T> Max<T>(this IEnumerable<IEnumerable<T>> lists, IComparer<IEnumerable<T>> comparer)
        {
            var max = lists.First();
            foreach (var list in lists.Skip(1))
            {
                if (comparer.Compare(list, max) > 0) max = list;
            }
            return max;
        }
        public class Comparer<T> : IComparer<IEnumerable<T>> where T: IComparable<T>
        {
            public int Compare(IEnumerable<T> x, IEnumerable<T> y)
            {
                foreach(var ab in  x.Zip(y,(a,b)=>new{a,b}))
                {
                    var res=ab.a.CompareTo(ab.b);
                    if (res != 0) return res;
                }
                return x.Count() - y.Count();
            }
        }
    }
