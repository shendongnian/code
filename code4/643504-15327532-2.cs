    public class Service1 : IService1
        {
            // note that if client is not authenticated, this code will never get a chance to execute
            // exception will happen before that
            // therefore there is no need to decorate this method with a
            // [PrincipalPermission(SecurityAction.Demand, Authenticated=true)] attribute        
            public string GetData()
            {
                try
                {
                    var identity = Thread.CurrentPrincipal.Identity;
                    return string.Concat(identity.Name, ",", identity.IsAuthenticated, ",", identity.AuthenticationType);
                }
                catch (Exception e)
                {
                    return string.Concat(e.Message, "\\r\\n", e.StackTrace);
                }
            }
        }
