    using System;
    using System.Web;
    
    namespace RestService
    {
        public class TestPreventCookie : IHttpModule
        {
            public void Dispose()
            {
            }
            public void Init(HttpApplication application)
            {
                application.BeginRequest +=
                    (new EventHandler(this.Application_BeginRequest));
                application.PostAcquireRequestState +=
                    (new EventHandler(this.Application_PostAcquireRequestState));
    
            }
            private void Application_BeginRequest(Object source, EventArgs e)
            {
                //prevent session cookie from reaching the service
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                if (context.Request.Path.StartsWith("/ServiceFolder"))
                {
                    context.Request.Cookies.Remove("ASP.NET_SessionId");
                }
            }
            private void Application_PostAcquireRequestState(Object source, EventArgs e)
            {
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                if (context.Request.Path.StartsWith("/ServiceFolder"))
                {
                    var s = context.Session;
                    if (s != null)
                        s.Abandon();
                }
            }
        }
    }
