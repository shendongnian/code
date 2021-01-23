    public class ProductComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] _x = x.Split(',');
            string[] _y = y.Split(',');
            double priceY = double.Parse(_y[0]);
            double priceX = double.Parse(_x[0]);
            return priceX.CompareTo(priceY);
        }
    }
