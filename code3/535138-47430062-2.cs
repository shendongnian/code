        public static bool Contain<T>(List<T> a, List<T> b)
        {
            if (a.Count <= 10 && b.Count <= 10)
            {
                return a.Any(b.Contains);
            }
            if (a.Count > b.Count)
            {
                return Contain((IEnumerable<T>) b, (IEnumerable<T>) a);
            }
            return Contain((IEnumerable<T>) a, (IEnumerable<T>) b);
        }
       
        public static bool Contain<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            HashSet<T> j = new HashSet<T>(a);
            return b.Any(j.Contains);
        }
