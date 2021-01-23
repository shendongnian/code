    using System;
    using System.Web;
    
    namespace Demo.Website.Modules
    {
        public class XfoHeaderModule : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.PreSendRequestHeaders += ContextPreSendRequestHeaders;
            }
    
            public void Dispose()
            {
            }
    
            private void ContextPreSendRequestHeaders(object sender, EventArgs e)
            {
                HttpContext.Current.Response.Headers.Add("X-Frame-Options", "Deny");
            }
        }
    }
