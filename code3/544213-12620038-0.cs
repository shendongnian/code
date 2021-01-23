    public class MyComparer : IComparer<A>
    {
        public int Compare(A x, A y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }
