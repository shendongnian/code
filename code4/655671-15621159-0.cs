    if (HttpContext.Request.Cookies["last_visited"]==null)
    {
        HttpCookie cookie = new HttpCookie("last_visited",DateTime.Now.ToString());
        cookie.Expires = DateTime.Now.AddDays(10);
        HttpContext.Response.Cookies.Add(cookie);
    }
    else if(HttpContext.Request.Cookies["last_visited"]!=null)
    {
        ViewBag.last_visited = HttpContext.Request.Cookies["last_visited"].Value;
    }
