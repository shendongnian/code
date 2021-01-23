    class Response
    {
        public List<IYourData> Data;
        public YourEnum ReturnType;
    }
    public class ResponseData : IYourData { ... }  
    public class ErrorData : IYourData { ... }  
