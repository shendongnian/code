    public class ApiControllerBase : ApiController
    {
       ...
       // Other code
       ...
       public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
       {
          return base
             .ExecuteAsync(controllerContext, cancellationToken)
             .ContinueWith(t =>
             {
                t.Result.Headers.CacheControl = new CacheControlHeaderValue()
                {
                   NoStore = true,
                   NoCache = true,
                   MaxAge = new TimeSpan(0),
                   MustRevalidate = true
                };
                t.Result.Headers.Pragma.Add(new NameValueHeaderValue("no-cache"));
                t.Result.Content.Headers.Expires = DateTime.Parse("01 Jan 1990 00:00:00 GMT");
                return t.Result;
             }, cancellationToken);
       }
    }
