     private const string HttpContext = "MS_HttpContext";
     private const string RemoteEndpointMessage =
         "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
     private const string OwinContext = "MS_OwinContext";
     private string GetClientIp(HttpRequestMessage request)
     {
           // Web-hosting
           if (request.Properties.ContainsKey(HttpContext ))
           {
                HttpContextWrapper ctx = 
                    (HttpContextWrapper)request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
           }
           
           // Self-hosting
           if (request.Properties.ContainsKey(RemoteEndpointMessage))
           {
                RemoteEndpointMessageProperty remoteEndpoint =
                    (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }
           // Self-hosting using Owin
           if (request.Properties.ContainsKey(OwinContext))
           {
               OwinContext owinContext = (OwinContext)request.Properties[OwinContext];
               if (owinContext != null)
               {
                   return owinContext.Request.RemoteIpAddress;
               }
           }
            return null;
     }
