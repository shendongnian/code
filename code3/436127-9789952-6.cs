    public class TestHandler : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage,
            CancellationToken, Task<HttpResponseMessage>> _handlerFunc;
        public TestHandler()
        {
            _handlerFunc = (r, c) => Return200();
        }
        public TestHandler(Func<HttpRequestMessage,
            CancellationToken, Task<HttpResponseMessage>> handlerFunc)
        {
            _handlerFunc = handlerFunc;
        }
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handlerFunc(request, cancellationToken);              
        }
        public static Task<HttpResponseMessage> Return200()
        {
            return Task.Factory.StartNew(
                () => new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
