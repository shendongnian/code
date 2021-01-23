    public class ConnectionHandler : DelegatingHandler {
    
            public HttpClient HttpClient {get;set;}
            public TestHandler(HttpMessageHandler handler) {
                this.InnerHandler = handler;
            }
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                // Do your login stuff here
                return base.SendAsync(request, cancellationToken)  // Make your actual request
                  .ContinueWith(t => {
                                // Do your logout stuff here
                                } 
            }
        }
