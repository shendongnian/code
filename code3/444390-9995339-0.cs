    class MyList<T> { 
      private List<T> _list = new List<T>();
      private object _sync = new object();
      public void Add(T value) {
        lock (_sync) {
          _list.Add(value);
        }
      }
      public bool Find(Predicate<T> predicate) {
        lock (_sync) {
          return _list.Find(predicate);
        }
      }
      public T FirstOrDefault() {
        lock (_sync) {
          return _list.FirstOrDefault();
        }
      }
    }
