    using System;
    using System.Web;
    using System.Collections;
    
    public class HelloWorldModule : IHttpModule
    {
        public String ModuleName
        {
            get { return "HelloWorldModule"; }
        }
    
        public void Init(HttpApplication application)
        {
             application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
             application.EndRequest += (new EventHandler(this.Application_EndRequest));
    
        }
    
        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<h1><font color=red>HelloWorldModule: Beginning of Request</font></h1><hr>");
        }
        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<hr><h1><font color=red>HelloWorldModule: End of Request</font></h1>");
        }
        public void Dispose()
        {
        }
    }
