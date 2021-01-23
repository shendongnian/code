    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = ddl.SelectedValue;
        string id2 = ddl2.SelectedValue;
        HttpCookie cookie = new HttpCookie("SecondId", id2);
        Response.Cookies.Add(cookie);
        Response.Redirect("http://sharepoint2007/sites/home/Lists/CustomList/DispForm.aspx?ID=" + id);
    }
    protected void OnLoad(object sender, EventArgs e)
    {
        string id2 = Request.Cookies["SecondId"];
        //send a cookie with an expiration date in the past so the browser deletes the other one
        //you don't want the cookie appearing multiple times on your server
        HttpCookie clearCookie = new HttpCookie("SecondId", null);
        clearCookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(clearCookie);
    }
