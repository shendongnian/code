    public class AuthorizeRoles : AuthorizeAttribute
    {
	List<string> roles = new List<string>(“your list of roles”);
     	bool isAuthenticated = false;
    for (int i = 0; i < roles.Count(); i++)
                    {
                        if (u.Role.Name == roles[i])
                        {
                            isAuthenticated = true;
                            break;
                        }
                    }
                    if (isAuthenticated)
                    {
                        SetCachePolicy(filterContext);
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/Error");
                    }
                }
    *Add this code in every controller’s begining*  [AuthorizeRoles(Roles = "SuperAdmin")]
