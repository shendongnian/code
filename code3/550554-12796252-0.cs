    private static Timer timer;
     private static void Main()
     {
       timer = new Timer(_ => OnCallBack(), null, 1000 * 10,Timeout.Infinite); //in 10 seconds
       Console.ReadLine();
     }
    
      private static void OnCallBack()
      {
        timer.Dispose();
        Thread.Sleep(3000); //doing some long operation
        timer = new Timer(_ => OnCallBack(), null, 1000 * 10,Timeout.Infinite); //in 10 seconds
      }
