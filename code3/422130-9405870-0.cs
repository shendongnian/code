    private readonly BlockingCollection<VsKeyInfo> _keyBuffer = 
          new BlockingCollection<VsKeyInfo>();
    private CancellationTokenSource _cancelWaitKeySource;
    // place a key into buffer
    public void PostKey(VsKeyInfo key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        _keyBuffer.Add(key);
    }
    // signal thread waiting on a key to exit Take
    public void CancelWaitKey()
    {
        if (_isExecutingReadKey && !_cancelWaitKeySource.IsCancellationRequested)
        {
            _cancelWaitKeySource.Cancel();
        }
    }
    // wait for a key to be placed on buffer
    public VsKeyInfo WaitKey()
    {
        try
        {
            // raise the StartWaitingKey event on main thread
            RaiseEventSafe(StartWaitingKey);
            // set/reset the cancellation token
            _cancelWaitKeySource = new CancellationTokenSource();
            _isExecutingReadKey = true;
            // blocking call
            VsKeyInfo key = _keyBuffer.Take(_cancelWaitKeySource.Token);
            return key;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
        finally
        {
            _isExecutingReadKey = false;
        }
    }
