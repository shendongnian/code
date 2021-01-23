     public void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new GenericPrincipal(identity, new string[] { authTicket.UserData });
                filterContext.HttpContext.User = principal;
            }
            var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = filterContext.ActionDescriptor.ActionName;
            var User = filterContext.HttpContext.User;
            var IP = filterContext.HttpContext.Request.UserHostAddress;
            var isAccessAllowed = CustomAuthenticationLogic.IsAccessAllowed(Controller, Action, User, IP);
            if (!isAccessAllowed)
            {
                // Code if user is authenticated
                FormsAuthentication.RedirectToLoginPage();
            }            
        }
