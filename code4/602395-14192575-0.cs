    class HttpMessageInvoker
    {
        private HttpMessageHandler handler;
        public HttpMessageInvoker(HttpMessageHandler handler)
        {
            this.handler = handler;
        }
        public void SendAsync()
        {
            Console.WriteLine("HttpMessageInvoker.SendAsync");
            this.handler.SendAsync();
        }
    }
    class HttpClient : HttpMessageInvoker
    {
        public HttpClient(HttpMessageHandler handler) : base(handler) { }
    }
    abstract class HttpMessageHandler
    {
        protected internal abstract void SendAync();
    }
    class HttpClientHandler : HttpMessageHandler
    {
        protected internal override void SendAync()
        {
            Console.WriteLine("HttpClientHandler.SendAsync");
        }
    }
