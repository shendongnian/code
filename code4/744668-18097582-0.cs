    public class OneUintAndStringKeyInfo
    {
        public uint IdOne { get; set; }
        public string Definition { get; set; }
        public class EqualityComparerOneUintAndStringKeyInfo : IEqualityComparer<OneUintAndStringKeyInfo>
        {
            public bool Equals(OneUintAndStringKeyInfo x, OneUintAndStringKeyInfo y)
            {
                return x.IdOne == y.IdOne && x.Definition == y.Definition;
            }
            public int GetHashCode(OneUintAndStringKeyInfo x)
            {
                return (x.IdOne.ToString() + x.Definition).GetHashCode();
            }
        }
    }
