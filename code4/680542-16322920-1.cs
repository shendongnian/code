    public class Event
    {
        public Event(string macAddress, DateTime time, string data)
        {
            MacAddress = macAddress;
            Time = time;
            Data = data;
        }
        public string MacAddress { get; set; }
        public DateTime Time { get; set; }
        public string Data { get; set; }
    }
    
    public class EventCollection
    {
        private readonly Dictionary<Tuple<string, DateTime>, Event> _Events = new Dictionary<Tuple<string, DateTime>, Event>();
        public void Add(Event e)
        {
            _Events.Add(new Tuple<string, DateTime>(e.MacAddress, e.Time), e);
        }
        public IList<Event> GetOldEvents(bool autoRemove)
        {
            DateTime old = DateTime.Now - TimeSpan.FromHours(8);
            List<Event> results = new List<Event>();
            foreach(Event e in _Events.Values)
                if (e.Time < old)
                    results.Add(e);
            // Clean up
            if (autoRemove)
                foreach(Event e in results)
                    _Events.Remove(new Tuple<string, DateTime>(e.MacAddress, e.Time));
            
            return results;
        }
    }
