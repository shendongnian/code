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
                application.EndRequest +=
                    (new EventHandler(this.Application_EndRequest));
    
            }
            private void Application_BeginRequest(Object source, EventArgs e)
            {
                //prevent session cookie from reaching the service
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                if(context.Request.Path.StartsWith("/ServiceFolder"))
                    context.Request.Cookies.Remove("ASP.NET_SessionId");
            }
            private void Application_EndRequest(Object source, EventArgs e)
            {
                //prevent service from setting a session cookie, thereby destroying any pre-existing session
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                if (context.Request.Path.StartsWith("/ServiceFolder"))
                    context.Response.Cookies.Remove("ASP.NET_SessionId");
            }
        }
    }
