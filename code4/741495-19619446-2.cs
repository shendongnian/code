    EndpointHostConfig.RazorNamespaces.Add("ServiceStack.Razor");
    EndpointHostConfig.RazorNamespaces.Add("MyApp");
    EndpointHostConfig.RazorNamespaces.Add("MyApp.Services");
    SetConfig(new EndpointHostConfig
    {
        DefaultRedirectPath = "/Home",
    });
