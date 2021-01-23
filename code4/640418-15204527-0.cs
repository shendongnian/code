 	class CustomMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> 
          SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IPrincipal principal = new GenericPrincipal(
                new GenericIdentity("myuser"), new string[] { "myrole" });
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
            return base.SendAsync(request, cancellationToken);
        }
    }
