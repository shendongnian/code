    public class MembershipHttpModule : IHttpModule
    {
        public void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Fires upon attempting to authenticate the user
            ...
        }
    
        public void Dispose()
        {
        }
    
        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
        }
    }
