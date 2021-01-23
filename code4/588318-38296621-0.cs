    class App
    {
      public static void Main()
      {
         Thread t = new Thread(DoWork(a, b));
         t.Start();
         if (t.IsAlive)
         {
             t.IsBackground = true;
         }
      }
    
      private static ThreadStart DoWork(int a, int b)
      {
          return () => { /*DoWork*/ var c = a + b; };
      }
    }
