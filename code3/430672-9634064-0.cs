        public class CustomType
        {
            public int Val1 { get; set; }
            public int Val2 { get; set; }
            public int Val3 { get; set; }
        }
        class CustomTypeComparer : IEqualityComparer<CustomType>
        {
            public bool Equals(CustomType x, CustomType y)
            { return x.Val1 == y.Val1 && x.Val2 == y.Val2; }
            public int GetHashCode(CustomType obj)
            { return obj.Val1.GetHashCode() ^ obj.Val2.GetHashCode(); }
        }
