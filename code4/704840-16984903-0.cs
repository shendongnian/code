    //Placeholder class
    public static class LogManager
    {
        public static ObservableCollection<LogMessage> Messages { get; }
    }
    public class LogMessage
    {
        public string Text { get; set; } 
    }
    public class LogManagerViewModel
    {
        public ObservableCollection<LogMessage> Messages { get { return LogManager.Messages; } }
    }
