    public class TypeDecidingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
                    HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Inspect the request here and determine the type to be used
            request.Content.Headers.Add("X-Type", "SomeType");
    
            return await base.SendAsync(request, cancellationToken);
        }
    } 
