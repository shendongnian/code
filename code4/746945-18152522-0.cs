    public class ExtComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            //return Path.GetExtension(x).CompareTo(Path.GetExtension(y)); or
            return System.String.Compare(Path.GetExtension(x), Path.GetExtension(y), System.StringComparison.Ordinal);
        }
    }
