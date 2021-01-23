    public class EventWrapper
    {
        public string Name { get; set; }
        public event EventHandler Event;
        public override string ToString()
        {
            return Name;
        }
        public void RaiseEvent(object sender)
        {
            EventHandler eh = Event;
            if (eh != null) {
                eh(sender, EventArgs.Empty);
            }
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
