    static void Main(string[] args) {
      Console.WriteLine("Press any key to connect...");
      Console.ReadKey(intercept: true);
      IFactory factory = Activator.GetObject(typeof(IFactory), @"tcp://127.0.0.1:2013/Factory.rem") as IFactory;
      EventWaitHandle signal = new EventWaitHandle(initialState: false, mode: EventResetMode.ManualReset);
      ThreadStart action = () => {
        signal.WaitOne();
        var result = factory.Hello("Eduard");
        Console.WriteLine(result);
      };
      foreach (var i in Enumerable.Range(0, 99))
        new Thread(action) { IsBackground = true }.Start();
      Console.WriteLine("Press any key to bombard server...");
      Console.ReadKey(intercept: true);
      signal.Set();
      Console.ReadKey(intercept: true);
    }
