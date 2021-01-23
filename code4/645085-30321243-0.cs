    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private HttpResponseMessage response;
     
        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            this.response = response;
        }
     
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseTask =  new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(response);
     
            return responseTask.Task;
        }
    }
    [TestMethod]
    public void TestGetContents()
    {
        var responseMessage = new HttpResponseMessage();
        var messageHandler = new FakeHttpMessageHandler(responseMessage);
        var client = new HttpClient(messageHandler);
        var sut = new Search(client);
     
        sut.SendSearch("urQuery");
     
        // Asserts
    }
