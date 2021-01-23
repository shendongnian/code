    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using System.Web.Security;
    using System.Web.SessionState;
    
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);    
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new MyCustomAssemblyResolver());
        }
    }
