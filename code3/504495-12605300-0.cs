    public class UsernamePasswordAuthentication : Attribute, IOperationBehavior, IParameterInspector
    {
        public void ApplyDispatchBehavior(OperationDescription operationDescription,
            DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(this);
        }
        public void AfterCall(string operationName, object[] outputs,
                              object returnValue, object correlationState)
        {
        }
        public object BeforeCall(string operationName, object[] inputs)
        {
            var usernamePasswordString = parseAuthorizationHeader(WebOperationContext.Current.IncomingRequest);
            if (usernamePasswordString != null)
            {
                string[] usernamePasswordArray = usernamePasswordString.Split(new char[] { ':' });
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                if ((username != null) && (password != null) && (Membership.ValidateUser(username, password)))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), new string[0]);
                    return null;
                }
            }
            // if we made it here the user is not authorized
            WebOperationContext.Current.OutgoingResponse.StatusCode =
                HttpStatusCode.Unauthorized;
            throw new WebFaultException<string>("Unauthorized", HttpStatusCode.Unauthorized);            
        }
        private string parseAuthorizationHeader(IncomingWebRequestContext request)
        {
            string rtnString = null;
            string authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authStr = authHeader.Trim();
                if (authStr.IndexOf("Basic", 0) == 0)
                {
                    string encodedCredentials = authStr.Substring(6);
                    byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
                    rtnString = new ASCIIEncoding().GetString(decodedBytes);
                }
            }
            return rtnString;
        }
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }
        public void Validate(OperationDescription operationDescription)
        {
        }
    }
