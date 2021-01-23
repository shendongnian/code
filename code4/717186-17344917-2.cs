    public class CloseConnectionHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                return base.SendAsync(request, cancellationToken).ContinueWith(t =>
                    {
                        var response = t.Result;
                        response.Headers.ConnectionClose = true;
                        return response;
                    });
            }
        }
