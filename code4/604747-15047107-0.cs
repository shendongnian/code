    class MainClass
    {
      public static void Main(string[] args)
      {  
        var currentEvidence = AppDomain.CurrentDomain.Evidence;
        var domain = AppDomain.CreateDomain("server", securityInfo: currentEvidence);
        new Task(() => domain.ExecuteAssembly(PathToSecondAssembly)).Start();
        new ManualResetEvent(false).WaitOne(); //wait forever
      }
    }
