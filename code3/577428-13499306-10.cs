    public class SignalRNewRelicIgnoreHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostMapRequestHandler += (s, a) =>
                {
                    if(HttpContext.Current.Handler is SignalR.Hosting.AspNet.AspNetHandler)
                    {
                        NewRelic.Api.Agent.NewRelic.IgnoreTransaction();
                    }
                };
        }
        public void Dispose()
        {
        }
    }
