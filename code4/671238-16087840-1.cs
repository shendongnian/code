    enum ResourceKind
    {
        Letter,
        Number
    }
    
    public class BaseResponse
    {
        public ResponseContent Response
        {
            get;
            set;
        }
    }
    
    public class ResponseContent
    {
        public List<ResultContent> Results
        {
            get;
            set;
        }
    }
    
    public class ResultContent
    {
        public ResourceKind Kind
        {
            get;
            set;
        }
    
        public List<string> Resources
        {
            get;
            set;
        }
    }
