        public class wwwOrderComparison : IComparer<String>
        {
            public int Compare(string x, string y)
            {
             	if(x == null && y == null)
                    return 0;
                if(x == null ^ y == null)
                    return x == null ? 1 : -1;
                var xWww = x.StartsWith("www");
                var yWww = y.StartsWith("www");
                if (xWww ^ yWww)
                    return xWww ? -1 : 1;
                return String.Compare(x, y);
            }
        }
        public class wwwEqualityComparison : IEqualityComparer<String>
        {
            public bool Equals(string x, string y)
            {
                if (x == null && y == null)
                    return true;
                if (x == null ^ y == null)
                    return false;
                var xWww = x.StartsWith("www");
                var yWww = y.StartsWith("www");
                if (xWww ^ yWww)
                    return xWww ? (x == "www." + y) : ("www." + x == y);
                return xWww == yWww;
            }
            public int GetHashCode(string obj)
            {
                return (obj.StartsWith("www.") ? obj : ("www." + obj)).GetHashCode();
            }
        }
