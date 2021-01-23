    public partial class Conference
    {
        [XmlIgnore]
        public bool SessionsSpecified
        {
            get { return false; }
        }
        public Session[] SerializableSessions
        {
            get { return new Sessions.ToArray(); }
            set { Sessions = value; }
        }
    }
