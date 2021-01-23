    public class Tuple<T, T2> 
    { 
        public Tuple(T first, T2 second) 
        { 
            First = first; 
            Second = second; 
        } 
        public T First { get; set; } 
        public T2 Second { get; set; }
    
        public override int GetHashCode()
        {
          return First.GetHashCode() ^ Second.GetHashCode();
        }
        public override Equals(object other)
        {
           Tuple<T, T2> t = other as Tuple<T, T2>;
           return t != null && t.First.Equals(First) && t.Second.Equals(Second);
        }
    
    }
