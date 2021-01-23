    public override async Task Invoke(IOwinContext context)
    {
       var response = context.Response;
       var request =  context.Request;
       response.OnSendingHeaders(state =>
       {
           var resp = (OwinResponse)state;
           resp.Headers.Add("X-MyResponse-Header", "Some Value");
           resp.StatusCode = 403;
           resp.ReasonPhrase = "Forbidden";
        }, response);
      var header = request.Headers["X-Whatever-Header"];
      await Next.Invoke(context);
    }
