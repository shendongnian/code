    return new NotModified();
---
    public class NotModified : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotModified);
            return Task.FromResult(response);
        }
    }
