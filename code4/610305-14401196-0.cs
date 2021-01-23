    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
           
         if (e.CommandName == "Edit")
         {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
     
                DropDownList ddl = (DropDownList)row.FindControl("ddlPosition");
                // Do whatever you want with the dropdownlist
         }
    }   
