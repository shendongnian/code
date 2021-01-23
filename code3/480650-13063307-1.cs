    public class CustomAuthAttribute : AuthorizeAttribute
    {
       private readonly IUserRoleService _userRoleService;
       private string[] _allowedRoles;
    
       public CustomAuthAttribute(params string[] roles)
       {
          _userRoleService = new UserRoleService();
          _allowedRoles = roles;
       }
       protected override bool AuthorizeCore(HttpContextBase httpContext)
       {
        //something like this.
        var userName = httpContext.User.Identity.Name;
        var userRoles = _userRoleService .GetUserRoles(userName); // return list of strings
        return _allowedRoles.Any(x => userRoles.Contains(x));
       }
