    <%
                
                     System.Web.HttpRequest oRequest = System.Web.HttpContext.Current.Request;
    
                     string header;
                     string ip;
    
                     header = "HTTP_X_FORWARDED_FOR";
                     ip = oRequest.ServerVariables[header];
                     Response.Write(string.Format("{0} - {1}", header, ip) + Environment.NewLine);
    
                     header = "REMOTE_ADDR";
                     ip = oRequest.ServerVariables[header];
                     Response.Write(string.Format("{0} - {1}", header, ip) + Environment.NewLine);
    
                     header = "HTTP_CLIENT_IP";
                     ip = oRequest.ServerVariables[header];
                     Response.Write(string.Format("{0} - {1}", header, ip) + Environment.NewLine);
    
                     header = "Request.UserHostAddress";
                     ip = oRequest.UserHostAddress;
                     Response.Write(string.Format("{0} - {1}", header, ip) + Environment.NewLine);
                
                 %>
