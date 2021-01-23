    if (Request.Cookies["gettingusername"] != null)
    {
        Response.Write("Cookie is not expired")
        Response.Write("Value exists : " + Request.Cookies["gettingusername"]);
    }
    else
    {
       Response.Write("Cookie is expired, creating a new cookie.");
       Response.Cookies.Add(new HttpCookie("gettingusername")
       {
           Value = textbox_username.Text,
           Expires = DateTime.Now.AddDays(1)
       });
    }
