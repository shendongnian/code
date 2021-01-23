    public class DummyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // work on the request 
           Trace.WriteLine(request.RequestUri.ToString());
     
           var response = await base.SendAsync(request, cancellationToken);
           response.Headers.Add("X-Dummy-Header", Guid.NewGuid().ToString());
           return response;
        }
    }
