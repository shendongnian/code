    foreach (string key in Request.Cookies.AllKeys)
    {
        HttpCookie cookie = new HttpCookie(key);
        cookie.Expires = DateTime.UtcNow.AddDays(-7);
        Response.Cookies.Add(cookie);
    }
