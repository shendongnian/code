    class IgnoreOrderComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            if (x == null || y == null) return false;
            return x.All(t => y.Contains(t));
        }
        public int GetHashCode(string[] arr)
        {
            if (arr == null) return int.MinValue;
            int hash = 19;
            foreach (string s in arr.Distinct().OrderBy(s => s))
            {
                hash = hash * 31 + s.GetHashCode();
            }
            return hash;
        }
    }
