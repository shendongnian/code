    protected void gvNewJoineeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
                if (!e.CommandSource.GetType().Name.Contains("GridView"))
                {
                    Service simplyHRClient = new Service();
                    GridViewRow row1 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    LinkButton lnkCust1 = (LinkButton)row1.FindControl("gvlnkBtnNewJoineeDetails");
