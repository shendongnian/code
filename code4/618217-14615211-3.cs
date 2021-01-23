    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsIdentity formsIdentity = new FormsIdentity(ticket);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(formsIdentity);
            var user = this.UserService.GetUserByEmail(ticket.Name);
            foreach (var role in user.Roles)
            {
                claimsIdentity.AddClaim(
                    new Claim(ClaimTypes.Role, role));
            }
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.Current.User = claimsPrincipal;
        }
    }
