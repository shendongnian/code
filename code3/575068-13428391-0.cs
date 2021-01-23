    class FastClearList<T> : IList<T>
    {
      List<T> inner = new List<T>();
      
      public void Clear()
      {
         inner = new List<T>(); // recreating list here will give O(1)
      }
    
      public IEnumerator<T> GetEnumerator()
      {
         return inner.GetEnumerator();
      }
      // forward everything else ...
    }
