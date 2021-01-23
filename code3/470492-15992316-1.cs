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
    public class GetNumberCommand : ICommand
    {
        public GetNumberCommand()
        {
            List<int> numbers = new List<int>
                {
                    1, 2, 3
                };
            infiniteLoopOnNumbers = new CircularEnumerable<int>(numbers).GetEnumerator();
        }
    
        IEnumerator<int> infiniteLoopOnNumbers; 
    
        public void Execute()
        {
            infiniteLoopOnNumbers.MoveNext();
        }
    
        public void Stop()
        {
            int value = infiniteLoopOnNumbers.Current;
        }
    }
