    namespace MvcExtensions.Infrastructure
    {
        public class CustomServerName : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.PreSendRequestHeaders += OnPreSendRequestHeaders;
            }
    
            public void Dispose() { }
    
            void OnPreSendRequestHeaders(object sender, EventArgs e)
            {
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }
    }
