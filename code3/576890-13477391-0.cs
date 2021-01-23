    ManualResetEvent _stopSignal = new ManualResetEvent(false); // Your "stopper"
    ManualResetEvent _exitedSignal = new ManualResetEvent(false);
    
    void DoProcessing() {
        try {
            while (!_stopSignal.WaitOne(0)) {
                DoSomething();
            }
        }
        finally {
            _exitedSignal.Set();
        }
    }
    
    void DoSomething() {
        //Some work goes here
    }
    public void Terminate() {
        _stopSignal.Set();
        _exitedSignal.WaitOne();
    }
