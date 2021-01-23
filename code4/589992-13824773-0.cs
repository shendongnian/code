    public class ShirtComparer : IComparer<string>
    {
        private static readonly string[] Order = new[] { "XS", "S", "M", "L", "XL", "XXL", "UK10", "UK12" };
        public int Compare(string x, string y)
        {
            var xIndex = Array.IndexOf(Order, x);
            var yIndex = Array.IndexOf(Order, y);
            if (xIndex == -1 || yIndex == -1) 
                return string.Compare(x, y, StringComparison.Ordinal);
            return xIndex - yIndex;
        }
    }
