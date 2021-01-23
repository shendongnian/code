    protected void abcde(object sender, GridViewCommandEventArgs e)
        {
          if (e.CommandName == "cmdLink")
            {
    		string path = //some path;
    		Session["path"] = path;
    		LinkButton objButton = (LinkButton)e.Item.FindControl("lnkname"); //this is you are missing 
    		objButton.PostBackUrl = "~/somewhere/" + Session["path"].ToString()";
    		}
        }
