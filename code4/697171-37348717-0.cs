    SemaphoreSlim ss = new SemaphoreSlim(0);
    int result = -1;
    public async Task Method() {
        MethodWhichResultsInCallBack()
        await ss.WaitAsync(10000);    // Timeout prevents deadlock on failed cb
        lock(ss) {
             // do something with result
        }
    }
    public void CallBack(int _result) {
        lock(ss) {
            result = _result;
            ss.Release();
        }
    }
