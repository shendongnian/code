    public class CustomAuthorizationManager : ServiceAuthorizationManager 
    {
        private const string UserName = "username";
        private const string Password = "password";
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            string authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            if ((authHeader != null) && (authHeader != string.Empty))
            {
                string[] svcCredentials = System.Text.ASCIIEncoding.ASCII
                                            .GetString(Convert.FromBase64String(authHeader.Substring(6)))
                                            .Split(':');
                var user = new { Name = svcCredentials[0], Password = svcCredentials[1] };
                if ((user.Name.Equals(UserName) && user.Password.Equals(Password)))
                    return true;
                else
                    return false;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"PsmProvider\"");
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }
    }
