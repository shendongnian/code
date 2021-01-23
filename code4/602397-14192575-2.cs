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
