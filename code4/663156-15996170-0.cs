    public class MyServiceAuthorizationManager: System.ServiceModel.ServiceAuthorizationManager
        {
            public override bool CheckAccess(OperationContext operationContext, ref Message message)
            {
                var reqProp = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                var authHeader = new AuthorizationHeader(reqProp.Headers[HttpRequestHeader.Authorization]);
    
                var authorized = // decide if this message is authorized...
    
                if (!authorized)
                {
                    var webContext = new WebOperationContext(operationContext);
                    webContext.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                    webContext.OutgoingResponse.Headers.Add(HttpResponseHeader.WwwAuthenticate, String.Format("Bearer realm=\"{0}\"", baseUri.AbsoluteUri));
                }
    
                return authorized;
            }
    }
