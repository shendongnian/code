    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies["myCookie"];
        if (c != null)
            litCookie.Text = string.Format("Username {0} Passwort {1}", c["username"], c["password"]);
        else
            litCookie.Text = "No Cookie \"myCookie\" found!";
    }
    protected void btnSetCookie_Click(object sender, EventArgs e)
    {
        HttpCookie c = new HttpCookie("myCookie");
        c.Expires = DateTime.Now.Add(new TimeSpan(0, 1, 0));
        c.Values.Add("username", "franz");
        c.Values.Add("password", "1234");
        Response.Cookies.Add(c);
        litCookie.Text = "Cookie added! Please reload to load cookie";
        // or redirect manually
        // Response.Redirect("YOURSITE.aspx");
    }
