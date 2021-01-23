    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnLinkClick")
            {
                string path = //some path;
                Session["path"] = path;
                var button = e.CommandSource as LinkButton;
                button.PostBackUrl = path;
            }
        }
