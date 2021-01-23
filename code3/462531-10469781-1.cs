    // Main thread:
    private static ManualResetEvent event = new ManualResetEvent(true); // boolean parameter whether to set the initial state to signaled.
    
    public void OnPauseClick(...) {
       event.Reset();
    }
    public void OnResumeClick(...) {
       event.Set();
    }
    // Worker thread
    public void DoSth() {
       while (true) {
         // show some random text in a label control (btw. you have to invoke the action because you are not in the main thread)
         event.WaitOne(); // waits for the signal to be set
       }
    }
