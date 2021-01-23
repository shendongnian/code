    protected void gvFiles_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e) 
    { 
     
        if (e.CommandName == "edit") 
        { 
            int index = Convert.ToInt32(e.CommandArgument);
            string fileID = ((GridView)sender).DataKeys[index]["fileID"].ToString(); 
            Response.Redirect("irMain.aspx?@filename=" + fileID); 
        } 
    } 
 
