    public class Filter {
        public String Name { get; set; }
        public String Value { get; set; }
        public class Comparer : IEqualityComparer<Filter>
        {
            public bool Equals(Filter x, Filter y)
            {
               if(ReferenceEquals(x, y))
                   return true;
               else if(x==null || y==null)
                   return false;
               return x.Name  == y.Name
                   && x.Value == y.Value;
            }
            public int GetHashCode(Filter obj)
            {
                unchecked 
                {
                    int hash = 17;
                    hash = hash * 23 + obj.Name.GetHashCode();
                    hash = hash * 23 + obj.Value.GetHashCode();
                    return hash;
                }
            }
        }
    }
