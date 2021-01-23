    public static void WriteCookie(HttpContext context, Guid token)
    { 
        HttpCookie cookie = new HttpCookie("LoginControl");
        cookie.Value = token.ToString();
        cookie.Expires = DateTime.Now.AddHours(0.5);
        context.Response.Cookies.Add(cookie);
    }
