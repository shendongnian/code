    public class DummyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // work on the request 
           Trace.WriteLine(request.RequestUri.ToString());
     
           return base.SendAsync(request, cancellationToken)
               .ContinueWith(task =>
               {
                   // work on the response
                   var response = task.Result;
                   response.Headers.Add("X-Dummy-Header", Guid.NewGuid().ToString());
                  return response;
               });
        }
    }
