    public class TimerData
    {
        public long time;
        public string description;
    
        public TimerData(long t, string d)
        {
            this.time = t;
            this.description = d;
        }
    } 
    
        
    List<EventData> list = new List<EventData>();
    list.Add(new TimerData(50, "Description"));
