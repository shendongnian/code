     public class CustomAuthenticationLogic
    {
        public static bool IsAccessAllowed(string controller, string action, IPrincipal user, string ip)
        {
            if (controller == "projects" && action == "GetProjectTasks" && UserIsInRoleForProject("projectname", "role"))
            {
                return true;
            }               
            
        }
    } 
  
