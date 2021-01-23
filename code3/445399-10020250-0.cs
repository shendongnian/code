    //this simply provides a synchronized reference wrapper for the Boolean,
    //and prevents trying to "un-cancel"
    public class ThreadStatus
    {
       private bool cancelled;
    
       private object syncObj = new Object();
    
       public void Cancel() {lock(syncObj){cancelled = true;}}
    
       public bool IsCancelPending{get{lock(syncObj){return cancelled;}}}
    }
    
    public void RunListener(object status)
    {
       var threadStatus = (ThreadStatus)status;
    
       var listener = new SerialPort("COM1");
    
       listener.Open();
    
       //this will loop until we cancel it, the port closes, 
       //or DoSomethingWithData indicates we should get out
       while(!status.IsCancelPending 
             && listener.IsOpen 
             && DoSomethingWithData(listener.ReadExisting())
          Thread.Yield(); //avoid burning the CPU when there isn't anything for this thread
    
       listener.Dispose();
    }
    
    ...
    
    Thread backgroundThread = new Thread(RunListener);
    ThreadStatus status = new ThreadStatus();
    backgroundThread.Start(status);
    
    ...
    
    //when you need to get out...
    //signal the thread to stop looping
    status.Cancel();
    //and block this thread until the background thread ends normally.
    backgroundThread.Join()
