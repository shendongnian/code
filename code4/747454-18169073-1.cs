    protected void edit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        Session["SelectedUserProjectId"] = ((HiddenField)gvrow.FindControl("hId")).Value // This is where I am trying to get the selected value - but can't find a way to do so.
        var pi = int.Parse(Session["SelectedUserProjectId"].ToString());
        var ui = int.Parse(Session["SelectedUserId"].ToString());
        // Do some calls to get data, populate fields, and then...
    
        this.pnlEdit_ModalPopupExtender.Show();
    }
