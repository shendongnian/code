    public class TwitterResponse
    {
        private readonly RestResponseBase _response;
        private readonly Exception _exception;
    
        internal TwitterResponse(RestResponseBase response): this(response, null)
        {
        }
    
        internal TwitterResponse(RestResponseBase response, Exception exception)
        {
            _exception = exception;
            _response = response;
        }
    }
