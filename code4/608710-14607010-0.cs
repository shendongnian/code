    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MyService
    {
        [WebInvoke(UriTemplate = "*", Method = "*")]
        public Message HandleRequest()
        {
            var webContext = WebOperationContext.Current;
            var webClient = new WebClient();
            return webContext.CreateStreamResponse(webClient.OpenRead("http://site.com"), "text/html");
        }
    }
