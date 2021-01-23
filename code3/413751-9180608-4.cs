    public class SomeClass
    {
        public TimeSpan Time { get; set; }
        public string FormattedTime
        {
           get { return TimeSpanToString(Time); }
        }
        
        private static string TimeSpanToString(TimeSpan source)
        {
            // Code.
        }
    }
