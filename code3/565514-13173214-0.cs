    public class ProductComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] _x = x.Split(',');
            string[] _y = y.Split(',');
            return ((new CaseInsensitiveComparer()).Compare(_y[0], _x[0]));
        }
    }
