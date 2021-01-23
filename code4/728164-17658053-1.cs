    appBuilder.UseHttpMessageHandler(new MyNonDelegatingHandler());
    public class MyNonDelegatingHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent("Hello!");
            return Task.FromResult<HttpResponseMessage>(response);
        }
    }
