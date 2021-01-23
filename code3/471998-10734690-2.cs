    public class NotFoundWithMessageResult : IHttpActionResult
    {
        private string message;
        public NotFoundWithMessageResult(string message)
        {
            this.message = message;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Content = new StringContent(message);
            return Task.FromResult(response);
        }
    }
