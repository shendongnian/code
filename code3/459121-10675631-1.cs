    public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                base.OnAuthorization(actionContext);
                IManageUsers manageUser = new ManageUsers();
                //get authentication token from header + email
                string authenticationToken = string.Empty;
                string email = string.Empty;
                if (actionContext.Request.Headers.GetValues("email") != null && (!string.IsNullOrEmpty(Convert.ToString(actionContext.Request.Headers.GetValues("email").FirstOrDefault()))))
                {
    
    
                    if (actionContext.Request.Headers.GetValues("authenticationToken") != null && (!string.IsNullOrEmpty(Convert.ToString(actionContext.Request.Headers.GetValues("authenticationToken").FirstOrDefault()))))
                    {
                        authenticationToken = Convert.ToString(actionContext.Request.Headers.GetValues("authenticationToken").FirstOrDefault());
                        email = Convert.ToString(actionContext.Request.Headers.GetValues("email").FirstOrDefault());
                        //check if user is activated 
                        User user = manageUser.GetByEmail(email);
                        if (user != null)
                        {
                            //if user is not authentication
                            if (user.AuthenticationStatus != AuthenticationStatus.Authenticated)
                            {
                                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthenticated");
                                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                                return;
                            }
                            //user is authentication, now check authorization
                            string authenticationTokenPersistant = user.AuthorizationToken;
                            //if length is not equal to the saved token
                            var authenticationTokenEncrypted = manageUser.EncryptAuthenticationTokenAes(authenticationTokenPersistant, user.Key, user.IV);
                            if (authenticationToken != authenticationTokenEncrypted)
                            {
                                HttpContext.Current.Response.AddHeader("Email", email);
                                HttpContext.Current.Response.AddHeader("authenticationToken", authenticationToken);
                                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                                HttpContext.Current.Response.AddHeader("ErrorMessage", "Invalid token");
                                return;
                            }
    
                            HttpContext.Current.Response.AddHeader("Email", email);
                            HttpContext.Current.Response.AddHeader("authenticationToken", authenticationToken);
                            HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                           
                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.PreconditionFailed);
                            HttpContext.Current.Response.AddHeader("ErrorMessage", "Email does not exist");
                            return;
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.PreconditionFailed);
                        HttpContext.Current.Response.AddHeader("ErrorMessage", "Please provide authentication token");
                        return;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.PreconditionFailed);
                    HttpContext.Current.Response.AddHeader("ErrorMessage", "Please provide email address");
                    return;
                }
            }
       
