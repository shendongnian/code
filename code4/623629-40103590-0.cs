     protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
     {
        var service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IFooService)) as IFooService;
        // Other stuff
     }
