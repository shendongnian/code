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
            this.request = request;
            this.code = code;
            this.result = result;
        }
        private readonly HttpRequestMessage request;
        private readonly HttpStatusCode code;
        private readonly object result;
        
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return new Task<HttpResponseMessage>(() => request.CreateResponse(code, result));
        }
    }
