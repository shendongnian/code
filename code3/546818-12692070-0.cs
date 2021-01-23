    public void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Link")
        {
            int key = int.Parse(e.CommandArgument.ToString());
            Response.Redirect(string.Format(
                "http://mySite/index.aspx?id={0}", key));
        }
    }
