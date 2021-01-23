    [Serializable()]
    public class Message
    {
        public int MessageId {get; set;}
         
        private ProcessingReport processingReport = new ProcessingReport();
        ...
    }
