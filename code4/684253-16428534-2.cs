    class CustomEqualityComparer : IEqualityComparer<Tuple<string, DateTime>>
    {
    
        public bool Equals(Tuple<string, DateTime> lhs, Tuple<string, DateTime> rhs)
        {
            return
              StringComparer.CurrentCultureIgnoreCase.Equals(lhs.Item1, rhs.Item1)
           && lhs.Item2 == rhs.Item2;
        }
    
    
        public int GetHashCode(Tuple<string, DateTime> tuple)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode(tuple.Item1)
                 ^ tuple.Item2.GetHashCode();
        }
    }
