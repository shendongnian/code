    [ConfigurationElementType(typeof(CustomFormatterData))]
    public class MyFormatter : LogFormatter
    {
        public MyFormatter(NameValueCollection nvc)
        {
            //not used
        }
        public override string Format(LogEntry log)
        {
            ErrorEntry errorEntry = log as ErrorEntry;
            if (errorEntry != null)
            {
                return "This is the string with the custom values: " + errorEntry.UserId;
                //use properties of ErrorEntry
                //populate returnString
            }
            return "Not supported";
        }
    }
