    public class IgnoreOrderComparer : IEqualityComparer<IList<string>>
    {
        public IgnoreOrderComparer(StringComparer comparer)
        {
            this.Comparer = comparer;
        }
        public StringComparer Comparer { get; set; }
        public bool Equals(IList<string> x, IList<string> y)
        {
            if (x == null || y == null) return false;
            return !x.Distinct(Comparer).Except(y.Distinct(Comparer), Comparer).Any();
        }
        public int GetHashCode(IList<string> arr)
        {
            if (arr == null) return int.MinValue;
            int hash = 19;
            foreach (string s in arr.Distinct())
            {
                hash = hash + s.ToUpper().GetHashCode();
            }
            return hash;
        }
    }
