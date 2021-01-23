    public static void SetAuthenticationExpirationTicket(HttpContext currentContext)
    {
        //Take the current time, in UTC, and add the forms authentication timeout (plus one second for some elbow room ;-)
        var expirationDateTimeInUtc = DateTime.UtcNow.AddMinutes(FormsAuthentication.Timeout.TotalMinutes).AddSeconds(1);
        var authenticationExpirationTicketCookie = new HttpCookie("AuthenticationExpirationTicket");
        //The value of the cookie will be the expiration date formatted as milliseconds since 01.01.1970.
        authenticationExpirationTicketCookie.Value = expirationDateTimeInUtc.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("F0");
        authenticationExpirationTicketCookie.HttpOnly = false; //This is important, otherwise we cannot retrieve this cookie in javascript.
        authenticationExpirationTicketCookie.Secure = FormsAuthentication.RequireSSL;
        currentContext.Response.Cookies.Add(authenticationExpirationTicketCookie);
    }
