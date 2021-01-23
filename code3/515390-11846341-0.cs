    XmlSerializer serializer = new XmlSerializer(typeof(Trial));
    serializer.Serialize(stream, trialObject);
    public class Trial
    {
        public List<Event> Events;
    }
    public class Event
    {
        public string eventID;
        public string dogId;
        public string ukcNumber;
        public string breead;
        public string dogName;
    }
