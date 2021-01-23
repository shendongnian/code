      public class CircularEnumerable<T> : IEnumerable<T>
      {
        public CircularEnumerable (IEnumerable<T> sequence)
        {
          InfiniteLoop = sequence.Concat (this);
        }
      
        private readonly IEnumerable<T> InfiniteLoop;
    
        public IEnumerator<T> GetEnumerator ()
        {
          return InfiniteLoop.GetEnumerator ();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        {
          return InfiniteLoop.GetEnumerator ();
        }
      }
