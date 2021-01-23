  int DisposingFlag; // System.Boolean doesn't work with Interlocked.Exchange
  void IDisposable.Dispose()
  {
    if (Threading.Interlocked.CompareExchange(DisposingFlag, 1, 0) == 0)
    {
      Dispose(true);
      DisposingFlag = 2;
      Threading.Thread.MemoryBarrier();
      GC.SuppressFinalize(this);
    }
  }
  public bool Disposed { get {return (DisposingFlag != 0);} }
  public bool FullyDisposed { get {return (DisposingFlag > 1);} }
