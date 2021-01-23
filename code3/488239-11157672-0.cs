    class Ranch<T> : IEnumerable<T> {
      ...
      #region IEnumerable<T> Members
    
      public IEnumerator<T> GetEnumerator() {
        throw new NotImplementedException();
      }
    
      #endregion
    
      #region IEnumerable Members
    
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
      }
    
      #endregion
    }
