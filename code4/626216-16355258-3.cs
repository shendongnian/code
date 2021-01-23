    // enable API versioning
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new RouteVersionControllerSelector(GlobalConfiguration.Configuration));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IApiExplorer), new VersionedApiExplorer(GlobalConfiguration.Configuration));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IDocumentationProvider),
                                    new XmlCommentDocumentationProvider(System.IO.Path.GetDirectoryName(
                                        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                                                                        "\\Adventure.Api.v1.XML"));
