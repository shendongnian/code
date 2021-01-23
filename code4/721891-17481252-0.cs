    public class Event
    {
        private readonly ThirdPartyClass _eventFromArgus;
        public Event(ThirdPartyClass eventFromArgus)
        {
            _eventFromArgus = eventFromArgus;
        }
        public string ReaderName { get { return _eventFromArgus.DeviceName; } }
        // etc.
    }
