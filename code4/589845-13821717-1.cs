    class Foo
    {
      volatile int runCount;
      int maxRunCount;
      Timer timer;
      void RunFor(int max)
      {
        maxRunCount = max;
        timer = new System.Threading.Timer(_ =>
        {
          if (timer == null) return;
          Console.WriteLine("Run " + runCount);
          if (Interlocked.Increment(ref runCount) == maxRunCount)
          {
              timer.Dispose();
              timer = null;
          }
        }, null, 500, 500);
      }
    }
