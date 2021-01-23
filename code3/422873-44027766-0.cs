    HttpContext cu;
    string username = cu.User.Identity.Name;
    username = Guid.NewGuid().ToString();
    cu.Session["username"] = username;
    HttpCookie hc = new HttpCookie("username", username);
    hc.Domain = ".yourdomain.com";
    hc.Expires = DateTime.Now.AddDays(1d);
    cu.Response.Cookies.Add(hc);
