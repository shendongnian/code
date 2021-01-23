    public class MyServer : ServiceBase
    {
      private ManualResetEvent shutdown = new ManualResetEvent(false);
    
      protected override void OnStart(string[] args)
      {
        new Thread(
          () =>
          {
            while (!shutdown.WaitOne(YourInterval))
            {
              // Do work here.
            }
          }).Start();
      }
    
      protected override void OnStop()
      {
        shutdown.Set();
      }
    }
