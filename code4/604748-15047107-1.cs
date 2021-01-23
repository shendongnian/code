    class MainClass
    {
      public static void Main(string[] args)
      {
        var evAgain = AppDomain.CurrentDomain.Evidence;
        var domain = AppDomain.CreateDomain("name", securityInfo: evAgain);
        Console.WriteLine ("A");
        domain.CreateInstance(Assembly.GetExecutingAssembly().FullName,
            typeof(Run).FullName, false, 0, null, 
            new object[0], null, new object[0]);
        Console.WriteLine ("B");
        new ManualResetEvent(false).WaitOne();
      }
    }
