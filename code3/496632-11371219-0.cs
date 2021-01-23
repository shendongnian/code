    public class AuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication application)
        {
            application.AuthorizeRequest += this.Application_AuthorizeRequest;
        }
        private void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            if (!User.IsMember)
                context.Response.Redirect("~/Login.aspx?m=1");      
        }
    }
