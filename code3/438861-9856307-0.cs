    public IEnumerable<T> Values {
      get {
        _lock.EnterReadLock();
        try {
          foreach (T v in _collection.Values) {   
            yield return v;
          }
        } finally {
          _lock.ExitReadLock();
        }
      }
    }
