    public class Doc : SomeInterfaceFromTheDll
    {
      private readonly IVersion version; // An interface from the DLL.
      private readonly ManualResetEvent _complete = new ManualResetEvent(false);
      
      private bool downloadSuccessful;
      
      // ...
      public bool Download()
      {
        this.version.DownloadFile(this);
        // Wait for the event to be signalled...
        _complete.WaitOne();
        return this.downloadSuccessful;
      }
      public void Completed(short reason)
      {
        Trace.WriteLine(string.Format("Notify.Completed({0})", reason));
        this.downloadSuccessful = reason == 0;
        // Signal that the download is complete
        _complete.Set();
      }
      // ...
    }  
