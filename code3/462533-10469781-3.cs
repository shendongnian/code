    private static EventWaitHandle waitHandle = new ManualResetEvent(initialState: true); 
    // Main thread
    public void OnPauseClick(...) {
       waitHandle.Reset();
    }
    public void OnResumeClick(...) {
       waitHandle.Set();
    }
    // Worker thread
    public void DoSth() {
       while (true) {
         // show some random text in a label control (btw. you have to
         // dispatch the action onto the main thread)
         waitHandle.WaitOne(); // waits for the signal to be set
       }
    }
