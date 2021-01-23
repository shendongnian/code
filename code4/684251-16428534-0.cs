    class CustomEqualityComparer : IEqualityComparer<Tuple<string, DateTime>>
    {
    
        public bool Equals(Tuple<string, DateTime> lhs, Tuple<string, DateTime> rhs)
        {
            return
              lhs.Item1.Equals(rhs.Item1, StringComparison.CurrentCultureIgnoreCase) 
           && lhs.Item2.Equals(rhs.Item2);
        }
    
    
        public int GetHashCode(Tuple<string, DateTime> tuple)
        {
        }
    
    }
