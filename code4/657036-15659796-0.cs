    static void Main()
    {
      Thread t = new Thread (Go);
      t.Start();
      Console.WriteLine ("Thread t has ended!");
    }
    
    static void Go()
    {
      for (int i = 0; i < 10; i++) Console.Write ("y");
    }
