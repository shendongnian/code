    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly RoleEnum[] _acceptedRoles;
        public AuthorizeAttribute(params RoleEnum[] acceptedroles)
        {
            _acceptedRoles = acceptedroles;
        }
        public AuthorizeAttribute(params bool[] allowAll)
        {
            if (allowAll[0])
                _acceptedRoles = new RoleEnum[] { RoleEnum.Admin, RoleEnum.user};
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionHelper.UserInSession == null)//user not logged in
            {
                FormsAuthentication.SignOut();
                filterContext.Result =
                     new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {{ "controller", "Home" },
                                                 { "action", "Index" },
                                                 { "returnUrl",    filterContext.HttpContext.Request.RawUrl } });//send the user to login page with return url
                return;
            }
            if (!_acceptedRoles.Any(acceptedRole => SessionHelper.UserInSession.UserRoles.Any(currentRole => acceptedRole == currentRole.Role)))
                //allow if any of the user roles is among accepted roles. Else redirect to login page
                throw new UnauthorizedAccessException();
        }
    }
