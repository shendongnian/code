    public class CustomerOrdersDispatcher : HttpControllerDispatcher {
        public CustomerOrdersDispatcher(HttpConfiguration config) 
            : base(config) {
        }
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken) {
            
            // Do some stuff here...
            return base.SendAsync(request, cancellationToken);
        }
    }
