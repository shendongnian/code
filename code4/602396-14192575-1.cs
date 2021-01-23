    class HttpMessageInvoker
    {
        private HttpMessageHandler handler;
        public HttpMessageInvoker(HttpMessageHandler handler)
        {
            this.handler = handler;
        }
        public virtual void SendAsync()
        {
            Console.WriteLine("HttpMessageInvoker.SendAsync");
            this.handler.SendAsync();
        }
    }
    class HttpClient : HttpMessageInvoker
    {
        public HttpClient(HttpMessageHandler handler)
            : base(handler)
        {
        }
        public override void SendAsync()
        {
            Console.WriteLine("HttpClient.SendAsync");
            base.SendAsync();
        }
    }
