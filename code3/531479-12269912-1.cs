    if (Request.Cookies["thisuserlogin"] != null)
    {
        HttpCookie byeCookie = new HttpCookie("thisuserlogin");
        byeCookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(byeCookie);
        // Update Client
        Response.Redirect(Request.RawUrl);
    }
