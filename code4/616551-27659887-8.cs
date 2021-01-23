    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie hc = new HttpCookie("NameOfCookie");
            hc.Expires = DateTime.Now.AddSeconds(60);//this cookie will be remove after 60 seconds.
            hc.Value = ddl.SelectedValue;// save here for later using
            Response.Cookies.Add(hc);//sending to user
        }
