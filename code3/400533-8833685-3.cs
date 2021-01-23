        public class wwwOrderComparison : IComparer<String>
        {
            public int Compare(string x, string y)
            {
             	if(x == null && y == null)
                    return 0;
                if(x == null ^ y == null)
                    return 0;
                var xWww = x.StartsWith("www");
                var yWww = y.StartsWith("www");
                return (xWww && x == "www." + y) ? -1 : ((yWww && "www." + x == y) ? 1 : 0);
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
