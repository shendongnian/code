    new EndpointHostConfig
    {
        DefaultContentType = ContentType.Json,
        EnableFeatures = Feature.None
                                .Add(Feature.Json)
                                .Add(Feature.PredefinedRoutes),
        GlobalResponseHeaders = new Dictionary<string, string>(),
        DefaultRedirectPath = "/documentation"
    }
