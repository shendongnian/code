    class InitEx<T> : IEnumerable<T>
    {
      List<T> _data = new List<T>();
    
      public IEnumerator<T> GetEnumerator()
      {
        return _data.GetEnumerator();
      }
    
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return _data.GetEnumerator();
      }
    
      public void Add(T i)
      {
        _data.Add(i);
      }
    }
