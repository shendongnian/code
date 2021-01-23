    public delegate int CompareDlg<T>(T thisOne, T otherOne);
    public class QuickSort<T> 
    {
        #region private variable to sort inplace
        readonly private IList<T> itms;
        private CompareDlg<T> cmp;
        #endregion private variable to sort inplace
        #region properties
        public CompareDlg<T> Comparer
        {
            set { cmp = value; }
            get { return cmp; }
        }
        #endregion properties
        #region ctor
        private QuickSort() { } //     Hide parameterless constructor
        /// <summary>
        /// Constructor, requires generic List of Ts 
        /// where T must implement CompareTo() method...
        /// </summary>
        /// <param name="list">List of T elements to sort</param>
        public QuickSort(IList<T> list) : this(list, null) { }
        /// <summary>
        /// Constructor, requires generic List of Ts 
        /// where T must implement CompareTo() method,
        /// And Compare method to use when sorting,
        /// (Overrides default CompareTo() implemented by T) ...
        /// </summary>
        /// <param name="list">List of T elements to sort</param>
        /// <param name="compareDelegate">Method to use to compare elements</param>
        public QuickSort(IList<T> list, CompareDlg<T> compareDelegate)
            : this()
        {
            if (list.Count == 0) throw new InvalidOperationException(
                "Empty List passed to QuickSort.");
            var first = default(T);
            if (typeof(T).IsClass)
            {
                foreach (var t in list)
                    if (!((first = t).Equals(default(T))))
                        break;
                if (first.Equals(default(T)))
                    throw new InvalidOperationException(
                        "List passed to QuickSort contains all nulls.");
            }
            if (compareDelegate == null && !(first is IComparable<T>))
                throw new InvalidOperationException(string.Format(
                    "Type {0} does not implement IComparable<{0}>. " +
                    "Generic Type T must either implement IComparable " +
                    "or a comparison delegate must be provided.", typeof(T)));
            itms = list;
            cmp += compareDelegate ?? CompareDefault;
        }
        #endregion ctor
        #region public sort method
        public static void Sort(IList<T> itms) { (new QuickSort<T>(itms)).Sort(); }
        public void Sort(bool asc) { Sort(0, itms.Count - 1, asc); }
        public static void Sort(IList<T> itms, CompareDlg<T> compareDelegate)
        { (new QuickSort<T>(itms, compareDelegate)).Sort(); }
        public void Sort() { Sort(0, itms.Count - 1, true); }
        /// <summary>
        /// Executes QuickSort algorithm
        /// </summary>
        /// <param name="L">Index of left-hand boundary of partition to sort</param>
        /// <param name="R">Index of right-hand boundary of partition to sort</param>
        /// <param name="asc"></param>
        private void Sort(int L, int R, bool asc)
        {
            // Call iSort (insertion-sort) 
            if (R - L < 4) iSort(L, R);
            //for partitions smaller than 4 elements
            else
            {
                int i = (L + R) / 2, j = R - 1;
                // Next three lines to set upper and lower bounds
                if (Comparer(itms[L], itms[i]) > 0 == asc) Swap(L, i);
                if (Comparer(itms[L], itms[R]) > 0 == asc) Swap(L, R);
                if (Comparer(itms[i], itms[R]) > 0 == asc) Swap(i, R);
                Swap(i, j);
                // --------------------------------------------
                var p = itms[j]; // p = itms[j] is pivot element
                i = L;
                while (true)
                {
                    while (Comparer(itms[++i], p) < 0 == asc) { }
                    while (Comparer(itms[--j], p) > 0 == asc) { }
                    if (j < i) break;
                    Swap(i, j);
                }
                Swap(i, R - 1);
                Sort(L, i, asc);     // Sort  Left partition
                Sort(i + 1, R, asc); // Sort Right partition
            }
        }
        private static int CompareDefault(T thisOne, T otherOne)
        {
            if(!(thisOne is IComparable<T>)) 
                throw new InvalidCastException(
                    "Type must implement IComparable<T>");
            return (thisOne as IComparable<T>).CompareTo(otherOne);
        }
        #endregion public sort method
        #region private Helper methods
        private void Swap(int L, int R)
        {
            var t = itms[L];
            itms[L] = itms[R];
            itms[R] = t;
        }
        private void iSort(int L, int R)
        {
            for (var i = L; i <= R; i++)
            {
                var t = itms[i];
                var j = i;
                while ((j > L) && Comparer(itms[j - 1], t) > 0)
                {
                    itms[j] = itms[j - 1];
                    j--;
                }
                itms[j] = t;
            }
        }
        #endregion private Helper methods
    }
