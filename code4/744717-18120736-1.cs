    public class AuthenticationHttpModule : IHttpModule
    {
        private readonly IAuthenticationVerifier authenticateVerify;
        public AuthenticationHttpModule(IAuthenticationVerifier authenticateVerify)
        {
            this.authenticateVerify = authenticateVerify;
        }
        public void Dispose()
        {
        }
        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += this.OnAuthenticateRequest;
            application.EndRequest += this.OnEndRequest;
        }
        private void OnAuthenticateRequest(object source, EventArgs eventArgs)
        {
            var app = (HttpApplication)source;
            try
            {
                var user = this.authenticateVerify.DoAuthentication(app.Request);
                app.Context.User = user;
            }
            catch (InvalidCredentialException)
            {
                this.DenyAccess(app);
            }
        }
        private void OnEndRequest(object source, EventArgs eventArgs)
        {
            ...
        }
    }
