    public class AuthModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest);
        }
    
        public void Dispose() { }
            
        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var isAuthenticated = ((HttpApplication) sender).Context.User.Identity.IsAuthenticated;
        }
    }
