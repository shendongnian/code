      public class EqualityComparer : IEqualityComparer<string>
      {
    
        public bool Equals(string x, string y)
        {
          return y.Contains(x);
        }
    
        public int GetHashCode(string obj)
        {
          return 1;
        }
       }
