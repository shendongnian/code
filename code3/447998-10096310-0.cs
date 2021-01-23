    HttpCookie cookie;
        cookie = Request.Cookies.Get("Basket");
        if (cookie != null)
        {
            cookie = new HttpCookie("Basket");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
        }
        Response.Redirect("~/Default.aspx");
