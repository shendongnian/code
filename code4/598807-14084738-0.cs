    public class TimeExtendedEventArgs : EventArgs
    {
      public TimeSpan TimeExtended { get; set; }
      public Player Player { get; set; }
    }
    
    public event EventHandler<TimeExtendedEventArgs> TimeExtended;
