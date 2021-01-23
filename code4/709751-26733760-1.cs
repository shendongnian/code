    public class MyAppender : AppenderSkeleton
    {
        public int IntProperty { get; set; }
        public override void Append(LoggingEvent loggingEvent)
        {
            // implement your functionality
        }
        public void AddStringProperty(string value)
        {
            // do whatever has to be done
        }
    }
