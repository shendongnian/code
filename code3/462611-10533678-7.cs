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
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var user = filterContext.HttpContext.User;
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var isAccessAllowed = CustomAuthenticationLogic.IsAccessAllowed(controller, action, user, ip);
            if (!isAccessAllowed)
            {
                // Code if user is authenticated
                FormsAuthentication.RedirectToLoginPage();
            }            
        }
