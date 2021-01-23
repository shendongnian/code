    public class ResponseHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request, cancellationToken);
            response.Result.StatusCode = response.Result.IsSuccessStatusCode ? System.Net.HttpStatusCode.OK : response.Result.StatusCode;
            return response;
        }
    } 
