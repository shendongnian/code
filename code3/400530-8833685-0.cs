        public class wwwEqualityComparison : IEqualityComparer<String>
        {
            public bool Equals(string x, string y)
            {
                var xWww = x.StartsWith("www");
                var yWww = y.StartsWith("www");
                if(xWww ^ yWww)
                    return ("www." + x == y || x == "www." + y);
                return xWww == yWww;
            }
            public int GetHashCode(string obj)
            {
                return (obj.StartsWith("www.") ? obj : ("www." + obj)).GetHashCode();
            }
        }
