    builder.Register(c => c.Resolve<HttpContextBase>().Request)
         .As<HttpRequestBase>()
         .InstancePerHttpRequest();
    builder.Register(c => c.Resolve<HttpContextBase>().Response)
         .As<HttpResponseBase>()
         .InstancePerHttpRequest();
    builder.Register(c => c.Resolve<HttpContextBase>().Server)
         .As<HttpServerUtilityBase>()
         .InstancePerHttpRequest();
    builder.Register(c => c.Resolve<HttpContextBase>().Session)
         .As<HttpSessionStateBase>()
         .InstancePerHttpRequest();
