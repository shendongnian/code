    var kernel = new Dictionary<Type, object>
    {
        { typeof(IHttpContextHelper), new HttpContextHelperMock() }
    };
    DependencyResolver.SetResolver(new DepepndecyResolverMock(kernel));
