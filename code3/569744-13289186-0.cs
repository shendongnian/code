    public static class DayManager
    {
         public static readonly object SyncRoot = new object();
         private static readonly Timer dayTimer;
         static DayManager()
         {
             dayTimer = new Timer { AutoReset = true; Enabled = true; Interval = 86400000d };
             dayTimer.Elapsed += OnDayTimerElapsed;
         }
         protected void OnDayTimerElapsed(object sender, ElapsedEventArgs e)
         {
             if(DayPassedEvent != null)
             {
                 DayPassedEvent(this, null);
             }
         }
         
         public event EventHandler DayPassedEvent;
    }
