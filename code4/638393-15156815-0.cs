    public class UberAuthorizeAttr : System.Web.DomainServices.AuthorizationAttribute
    {
        public string Application {get;set;}
        public string Topic {get;set;}
    
        public override bool Authorize(System.Security.Principal.IPrincipal principal)
        {
            // your custom behaviour
        }
    }
