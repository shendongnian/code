    public abstract class BaseGridViewModel
    {
    
        protected BaseGridViewModel()
        {
            Times = new List<TimeEvent>();
        }
        public IList<TimeEvent> Times {get; set;}
    
        public void Event(StopWatch watch, string message)
        {
            Times.Add(new TimeEvent(watch.ElapsedMilliseconds, message));
        }
    
    }
