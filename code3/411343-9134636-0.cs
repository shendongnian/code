    public class UserAuthenticator : IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += new EventHandler(this.OnAuthenticateRequest);
            application.EndRequest += new EventHandler(this.OnEndRequest);
        }
        public void OnAuthenticateRequest(object source, EventArgs eventArgs)
        {
            HttpApplication app = (HttpApplication)source;
            // Get the request stream
            Stream httpStream = app.Request.InputStream;
            // I converted the stream to string so I can search for a known substring
            byte[] byteStream = new byte[httpStream.Length];
            httpStream.Read(byteStream, 0, (int)httpStream.Length);
            string strRequest = Encoding.ASCII.GetString(byteStream);
            // This is the end of the initial SOAP envelope
            // Not sure if the fastest way to do this but works fine
            int idx = strRequest.IndexOf("</t:RequestSecurityToken></s:Body></s:Envelope>", 0);
            httpStream.Seek(0, SeekOrigin.Begin);
            if (idx != -1)
            {
                // Initial packet found, do nothing (HTTP status code is set to 200)
                return;
            }
            //the Authorization header is checked if present
            string authHeader = app.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader))
            {
                if (authHeader == null || authHeader.Length == 0)
                {
                    // No credentials; anonymous request
                    return;
                }
                authHeader = authHeader.Trim();
                if (authHeader.IndexOf("Basic", 0) != 0)
                {
                    // the header doesn't contain basic authorization token
                    // we will pass it along and
                    // assume someone else will handle it
                    return;
                }
                string encodedCredentials = authHeader.Substring(6);
                byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
                string s = new ASCIIEncoding().GetString(decodedBytes);
                string[] userPass = s.Split(new char[] { ':' });
                string username = userPass[0];
                string password = userPass[1];
                // the user is validated against the SqlMemberShipProvider
                // If it is validated then the roles are retrieved from 
                // the role provider and a generic principal is created
                // the generic principal is assigned to the user context
                // of the application
                if (Membership.ValidateUser(username, password))
                {
                    string[] roles = Roles.GetRolesForUser(username);
                    app.Context.User = new GenericPrincipal(new
                    GenericIdentity(username, "Membership Provider"), roles);
                }
                else
                {
                    DenyAccess(app);
                    return;
                }
            }
            else
            {
                app.Response.StatusCode = 401;
                app.Response.End();
            }
        }
        public void OnEndRequest(object source, EventArgs eventArgs)
        {
            // The authorization header is not present.
            // The status of response is set to 401 Access Denied.
            // We will now add the expected authorization method
            // to the response header, so the client knows
            // it needs to send credentials to authenticate
            if (HttpContext.Current.Response.StatusCode == 401)
            {
                HttpContext context = HttpContext.Current;
                context.Response.AddHeader("WWW-Authenticate", "Basic Realm");
            }
        }
        private void DenyAccess(HttpApplication app)
        {
            app.Response.StatusCode = 403;
            app.Response.StatusDescription = "Forbidden";
            // Write to response stream as well, to give the user 
            // visual indication of error 
            app.Response.Write("403 Forbidden");
            app.CompleteRequest();
        }
    }
