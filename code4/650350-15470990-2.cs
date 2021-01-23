    protected void yourgridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdnum")
            {
                this.FindControl("grdwv" + e.CommandArgument).Visible = false;
    //i am assuming other gridview is on your .aspx page
            }
        }
