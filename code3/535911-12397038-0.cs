    public sealed class TimeEvent
    {
      public long Elapsed {get; private set;}
      public string Description { get; private set;}
      public TimeEvent(long elapsedTime, string descriptionOfEvent)
      {
        this.Elapsed = elapsedTime;
        this.Description = descriptionOfEvent;
      }
    }
    
    public IList<TimeEvent> TimerEvents {get; set;}
    
    vm.Timer.Add(new TimeEvent(sw.ElapsedMillisends, "After event 1"));
