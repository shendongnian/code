    public class FooHandler  : HttpTaskAsyncHandler
    {
      public override Task ProcessRequestAsync(HttpContext context)
      {
        return new AdRequest().ProcessRequest();
      }
    }
    public class AdRequest
    {
      public Task<String> ProcessRequest()
      {
        return Task.FromResult("foo");
      }
    }
