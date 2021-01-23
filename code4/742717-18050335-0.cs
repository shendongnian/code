    public class MyTestHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
                                     HttpRequestMessage request,
                                         CancellationToken cancellationToken)
        {
            var local = request.Properties["MS_IsLocal"] as Lazy<bool>;
            bool isLocal = local != null && local.Value;
    
            if (isLocal)
            {
                if (request.Headers.GetValues("X-Testing").First().Equals("true"))
                {
                    var dummyPrincipal = new GenericPrincipal(
                                            new GenericIdentity("dummy", "dummy"),
                                              new[] { "myrole1" });
    
                    Thread.CurrentPrincipal = dummyPrincipal;
    
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = dummyPrincipal;
                }
            }
    
            return await base.SendAsync(request, cancellationToken);
        }
    }
