    public class EventWrapper
    {
        public string Name { get; set; }
        public EventHandler Event { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class ActionWrapper
    {
        public string Name { get; set; }
        public Action<object, EventArgs> Action { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
