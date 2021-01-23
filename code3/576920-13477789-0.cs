    public class PBookComparer : IComparer<PBook>
    {
        public int Compare(PBook x, PBook y)
        {
            // Sort null items to the top; you can drop this
            // if you don't care about null items.
            if (x == null)
                return y == null ? 0 : -1;
            else if (y == null)
                return 1;
            // Comparison of sums.
            var sumCompare = x.Sum().CompareTo(y.Sum());
            if (sumCompare != 0)
                return sumCompare;
            // Sums are the same; return comparison of strings 
            return String.Compare(x.RandomString, y.RandomString);
        }
    }
