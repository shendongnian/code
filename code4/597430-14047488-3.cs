    class IgnoreOrderComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            if (x == null || y == null) return false;
            return !x.Distinct().Except(y.Distinct()).Any();
        }
        public int GetHashCode(string[] arr)
        {
            if (arr == null) return int.MinValue;
            int hash = 19;
            foreach (string s in arr.Distinct())
            {
                hash = hash + s.GetHashCode();
            }
            return hash;
        }
    }
