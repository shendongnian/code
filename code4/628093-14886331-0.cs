    public class OneTimeEnumerable<T> : IEnumerable<T>
    {
      public OneTimeEnumerable(IEnumerable<T> source)
      {
        _source = source; 
      }
    
      private IEnumerable<T> _source;
      private bool _wasEnumerated = false;
    
      public IEnumerator<T> GetEnumerator()
      {
        if (_wasEnumerated)
        {
          throw new Exception("double enumeration occurred");
        }
        _wasEnumerated = true;
        return _source.GetEnumerator();
      }
    
    }
