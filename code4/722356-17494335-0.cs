    public class MyOrderedEnumerable<T> : IOrderedEnumerable<T>
    {
        private IEnumerable<T> Original;
        private IOrderedEnumerable<T> Sorted;
	
        public MyOrderedEnumerable(IEnumerable<T> orig)
        {
                Original = orig;
                Sorted = null;
        }
	
        private void ApplyOrder<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
                var before = Sorted != null ? Sorted : Original;
                if (descending)
                        Sorted = before.OrderByDescending(keySelector, comparer);
                else
                        Sorted = before.OrderBy(keySelector, comparer);
        }
	
        #region Interface Implementations
	
        public IEnumerator<T> GetEnumerator()
        {
                return Sorted != null ? Sorted.GetEnumerator() : Original.GetEnumerator();
        }
	
        IEnumerator IEnumerable.GetEnumerator()
        {
                return GetEnumerator();
        }
	
        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(
                Func<T, TKey> keySelector,
                IComparer<TKey> comparer,
                bool descending)
        {
                var newSorted = new MyOrderedEnumerable<T>(Original);
                newSorted.ApplyOrder(keySelector, comparer, descending);
                return newSorted;
        }
	
        #endregion Interface Implementations
	
		
        //Ensure that OrderBy returns the right type. 
        //There are other variants of OrderBy extension methods you'll have to short-circuit
        public MyOrderedEnumerable<T> OrderBy<TKey>(Func<T, TKey> keySelector)
        {	
                Console.WriteLine("Ordering");
                var newSorted = new MyOrderedEnumerable<T>(Original);
                newSorted.Sorted = (Sorted != null ? Sorted : Original).OrderBy(keySelector);
                return newSorted;
        }
	
        public int Count()
        {
                Console.WriteLine("Fast counting..");
                var collection = Original as ICollection;
                return collection == null ? Original.Count() : collection.Count;
        }
	
        public static void Test()
        {
                var nums = new MyOrderedEnumerable<int>(Enumerable.Range(0,10).ToList());
                var nums2 = nums.OrderBy(x => -x);
                var z = nums.Count() + nums2.Count();
        }
    }
