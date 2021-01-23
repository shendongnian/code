    public class TestEvent : IEvent
    {
        public string A { get; set; } // Event specific property
        public string B { get; set; } // Event specific property
        public string Message { get { return String.Format("{0} {1}", A, B); } }
        // The event handler does not need to access A or B.
    }
