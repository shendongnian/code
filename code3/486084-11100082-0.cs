    public void JustDoIt(Action a, int interval, int times)
    {
        if (_isProcessing) return
        _isProcessing = true;
        for (int i = 0; i < times; i++)
        {
            a();
            Thread.Sleep(interval);
        }
        _isProcessing = false;
    }
