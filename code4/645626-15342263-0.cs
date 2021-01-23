    public class ResponseBase
    {
        public ResponseBase()
        {
        }
    
        public string CorrelationId { get; set; }
    
        public ResponseBase(string correlationId)
        {
            this.CorrelationId = correlationId;
        }
    }
