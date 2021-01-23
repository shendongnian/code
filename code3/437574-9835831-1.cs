    public void GetData()
    {
       //bind ur GridView
       GridViewUserScraps.DataSource = dt;
       GridViewUserScraps.DataBind();
    }
    protected void GridViews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Comment")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string scrapid = commandArgs[0];
            string uid = commandArgs[1];
        }
    }
