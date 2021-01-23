    protected void edit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            Session["SelectedUserProjectId"] = btndetails.CommandArgument;
           // Rest of implementation
        }
