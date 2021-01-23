    public class MyModule : IHttpModule {
        public String ModuleName { 
            get { return "MyModule"; } 
        }    
        
        public void Init(HttpApplication application) {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }
        
        private void Application_BeginRequest(Object source, EventArgs e) {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write(string.Format("The value of \"t\" is {0}", context.Request.QueryString["t"]);
        }        
        
        public void Dispose() 
        {
        }
    }
