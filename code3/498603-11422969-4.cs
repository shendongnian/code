    public class SecurityServiceProxy
    {
        public static UserInformation GetUserInformation(Guid userId)
        {
            var result = ServiceProxy.Execute<MySecurityService, UserInformation>
            (
                svc => svc.GetUserInformation(userId)
            );
   
            return result;
        }
        
        public static bool IsUserAuthorized(UserCredentials creds, ActionInformation actionInfo)
        {
            var result = ServiceProxy.Execute<MySecurityService, bool>
            (
                svc => svc.IsUserAuthorized(creds, actionInfo)
            );
   
            return result;
        }
     }
