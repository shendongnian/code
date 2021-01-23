    public BlockingBatchedQueue<T>
    {
      private readonly AutoResetEvent _are = new AutoResetEvent(false);
      private readonly LLQueue<T> _store;
      public void Add(T item)
      {
        _store.Enqueue(item);
        _are.Set();
      }
      public IEnumerable<T> Take()
      {
        _are.WaitOne();
        return _store.AtomicDequeueAll();
      }
      public bool TryTake(out IEnumerable<T> items, int millisecTimeout)
      {
        if(_are.WaitOne(millisecTimeout))
        {
          items = _store.AtomicDequeueAll();
          return true;
        }
        items = null;
        return false;
      }
    }
