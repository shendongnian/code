    public class MyApplicationAuthHandler : BasicAuthenticationHandler {
        public MyApplicationAuthHandler() 
            : base(suppressIfAlreadyAuthenticated: true) { }
        protected override IPrincipal AuthenticateUser(
            HttpRequestMessage request, 
            string username, 
            string password, 
            CancellationToken cancellationToken) { 
            //this method will be called only if the request
            //is not authanticated.
            
            //If you are using forms auth, this won't be called
            //as you will be authed by the forms auth bofore you hit here
            //and Thread.CurrentPrincipal would be populated.
            //If you aren't authed:
            //Do you auth here and send back an IPrincipal 
            //instance as I do below.
            var membershipService = (IMembershipService)request
                .GetDependencyScope()
                .GetService(typeof(IMembershipService));
            var validUserCtx = membershipService
                .ValidateUser(username, password);
            return validUserCtx.Principal;
        }
        protected override void HandleUnauthenticatedRequest(UnauthenticatedRequestContext context) {
            
            // Do nothing here. The Autharization 
            // will be handled by the AuthorizeAttribute.
        }
    }
