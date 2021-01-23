    public class Sleeper
    {
      private TimeSpan remaining = TimeSpan.Zero;
    
      public TimeSpan GetRemaining()
      {
        lock (this)
        {
          if (remaining > TimeSpan.Zero)
          {
            Monitor.Pulse(this);
            Monitor.Wait(this);
          }
          return remaining;
        }
      }
    
      public void Sleep(TimeSpan timeout)
      {
        lock (this)
        {
          if (remaining > TimeSpan.Zero)
          {
            throw new InvalidOperationException("Sorry, but I'm not safe for multiple sleepers.");
          }
          remaining = timeout;
          DateTime expires = DateTime.UtcNow.Add(remaining);
          bool complete = remaining <= TimeSpan.Zero;
          while (!complete)
          {
            bool complete = Monitor.Wait(this, remaining);
            remaining = expire - DateTime.UtcNow;
            if (remaining <= TimeSpan.Zero)
            {
              complete = true;
            }
            if (complete)
            {
              remaining = TimeSpan.Zero;
            }
            Monitor.Pulse(this);
          }
        }
      }
    }
