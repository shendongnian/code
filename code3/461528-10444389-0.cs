    CookieContainer c = new CookieContainer();
    var cookies = c.GetCookies(new Uri("http://www.google.com"));
    foreach (Cookie co in cookies)
    {
      co.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1));
    }
