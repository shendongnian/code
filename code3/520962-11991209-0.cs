    static readonly object locker = new object();
    private static bool ready, go;
    public static void Thread1()
    {
      IEnumerable<Action> actions = new List<Action>()
      {
       () => Console.WriteLine("1"),
       () => Console.WriteLine("t2 has printed 1, so we now print 2"),
       () => Console.WriteLine("t2 has printed 2, so we now print 3")
      };
      foreach (var action in actions)
      {
        lock (locker)
        {
          while (!ready) Monitor.Wait(locker);
          ready = false;
          go = true;
          Monitor.PulseAll(locker);
          action();
        } 
      }
    }
    public static void Thread2()
    {
      IEnumerable<Action> actions = new List<Action>()
      {
       () => Console.WriteLine("t1 has printed 1, so we now print 1"),
       () => Console.WriteLine("t1 has printed 2, so we now print 2"),
       () => Console.WriteLine("t1 has printed 3, so we now print 3")
      };
      foreach (var action in actions)
      {
        lock (locker)
        {
          ready = true;
          Monitor.PulseAll(locker);
          while (!go) Monitor.Wait(locker);
          go = false;
          action();
        }
      }
    }
    private static void Main(string[] args)
    {
      Thread t1 = new Thread(new ThreadStart(() => Thread1()));
      Thread t2 = new Thread(new ThreadStart(() => Thread2()));
      t1.Start();
      t2.Start();
      t2.Join();
      t1.Join();
    }
