    public abstract class AbstractAuthenticationController : Controller
    {
        private readonly IAuthenticationService _authService;
        protected AbstractAuthenticationController()
        {
            _authService = AuthenticationServiceFactory.Create();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            EnsureUserIsAuthenticated();
        }
        internal void EnsureUserIsAuthenticated()
        {
            if (!_authService.IsUserAuthenticated())
            {
                _authService.Login();
            }
        }
        protected string GetUsernameForAuthenticatedUser()
        {
            var identityName = System.Web.HttpContext.Current.User.Identity.Name;
            var username = _authService.GetUsername(identityName);
            if (username == null) throw new UsernameNotFoundException("No Username for " + identityName);
            return username;
        }
    }
