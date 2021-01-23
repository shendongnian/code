    public void Writer(object toWrite) {
      this.rwLock.EnterWriteLock();
      try {
        int tailIndex = this.list.Count;
        this.list.Add(toWrite);
    
        if (..condition1..)
          this.queue1.Enqueue(tailIndex);
        if (..condition2..)
          this.queue2.Enqueue(tailIndex);
        if (..condition3..)
          this.queue3.Enqueue(tailIndex);
        ..etc..
      } finally {
        this.rwLock.ExitWriteLock();
      }
    }
