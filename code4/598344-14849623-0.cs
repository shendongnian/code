        using ServiceStack.Api.Swagger;
        public override void Configure(Container container)
        {
          ...
          Plugins.Add(new SwaggerFeature());
          ...
        }
