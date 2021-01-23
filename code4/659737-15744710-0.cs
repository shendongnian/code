    public class MyDummyHttpHandler : DelegatingHandler
    {
      HttpResponseMessage response;
    
      public MyDummyHttpHandler(HttpResponseMessage response)
      {
        this.response = response;
      }
    
      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,    CancellationToken cancellationToken)
      {
        .....
        TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
        tsc.SetResult(this.response);
    
        return tsc.Task;
      }
    }
