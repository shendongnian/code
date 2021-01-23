     public class CustomAuthenticationLogic
    {
        public static bool IsAccessAllowed(string Controller, string Action, IPrincipal User, string IP)
        {
            if (Controller == "SomeAction" && UserIsInRoleForProject("project", "role"))
            {
                return true;
            }               
            
        }
    } 
  
