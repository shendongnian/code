    using System;
    using System.Threading;
    
    class App
    {
      static void Main()
      {
        var t = new Test();
        t.Start();
        Thread.Sleep(10000);
        Console.WriteLine("aborting");
        t.Stop();
      }
    }
    
    class Test
    {
    private int threadSleepMinutes = 60;
    
    private Thread serviceThread;
    
    private CancellationTokenSource tokenSource;
    
    public void Start()
    {
        // Some things renamed to anonymise... you get the idea!
        this.tokenSource = new CancellationTokenSource();
        this.serviceThread = new Thread(this.BigLoopMethod);
        this.serviceThread.IsBackground = true;
        this.serviceThread.Start();
    }
    
    public void Stop()
    {
        tokenSource.Cancel();
    
        // Wait 5s max
        int timeout = 5000;
        if (!serviceThread.Join(timeout))
        {
          serviceThread.Abort();
        }
    }
    
    public void BigLoopMethod()
    {
        try
        {
          var token = tokenSource.Token;
          do
          {
              int operationsToGo = 4; // Just dummy flags and 'stuff' methods here
              while (operationsToGo > 0 && !token.IsCancellationRequested)
              {
                  Console.WriteLine("work");
                  Thread.Sleep(1000);//DoStuff();
                  operationsToGo--;
              }
              Console.WriteLine("no more work");
          }
          while (!token.WaitHandle.WaitOne(this.threadSleepMinutes * 60000));
        }
        catch (Exception ex)
        {
            // Exception handling & logging here
        }
    }
    }
