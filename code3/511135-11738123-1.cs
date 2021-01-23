            return Redirect(
                Url.RouteUrl("DefaultApi", 
                    new { httproute = "", 
                          controller = "AuthenticationServiceWebApi", 
                          action = "AuthenticateUser", 
                          id = model.UserName,
                          id2 = model.Password
                }));
