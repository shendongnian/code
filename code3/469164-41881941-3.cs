    public class HttpActionResult : IHttpActionResult
    {
        public HttpActionResult(HttpRequestMessage request) : this(request, HttpStatusCode.OK)
        {
        }
        public HttpActionResult(HttpRequestMessage request, HttpStatusCode code) : this(request, code, null)
        {
        }
        public HttpActionResult(HttpRequestMessage request, HttpStatusCode code, object result)
        {
            Request = request;
            Code = code;
            Result = result;
        }
        public HttpRequestMessage Request { get; }
        public HttpStatusCode Code { get; }
        public object Result { get; }
        
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Request.CreateResponse(Code, Result));
        }
    }
