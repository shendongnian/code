    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SXEngine.Classx USER = (SXEngine.Classx)Session["APPOBJ"];        
    
            if (e.CommandName == "Select")
            {
                USER.bRowSelect = true;         
            }
            else
            {
                USER.bRowSelect = false ;
            }
        }
