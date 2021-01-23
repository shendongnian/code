    protected void gridviewListUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                //your code
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertUser", "alert('deleted');", true);
            }
        }
        
