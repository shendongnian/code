    public class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length < y.Length) return -1;
            if (x.Length > y.Length) return 1;
            return Comparer.Default.Compare(x, y);
        }
    }
