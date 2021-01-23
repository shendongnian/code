    public class LogEntity : GenericTableEntity 
    {
        // Since Timestamp is a DateTimeOffset
        public DateTime LogDate
        {
            get { return Timestamp.UtcDateTime; }
        }
        public string Message
        {
            get { return Properties["Message"].StringValue; }
        }
    }
