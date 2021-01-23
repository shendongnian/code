    public class SelfAdjustingTimer
    {
      public Timer Timer { get; protected set; }
      public int Interval { get; private set; }
      public SelfAdjustingTimer(int interval)
      {
        this.Interval = interval;
        this.Timer = new Timer(Callback, null, Timeout.Infinite, interval);
      }
      private void Callback(object sender)
      {
        this.Timer.Change(Timeout.Infinite, this.Interval);
      }
    }
