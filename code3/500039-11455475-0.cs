    using System;
    using System.Web;
    namespace IISHeaders
    {
        public class RemoveServerHeaderModule : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.PreSendRequestHeaders += OnPreSendRequestHeaders;
            }
            public void Dispose() { }
            static void OnPreSendRequestHeaders(object sender, EventArgs e)
            {
                // remove the "Server" Http Header
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }
    }
