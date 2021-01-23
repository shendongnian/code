    protected void gridOccupants_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert") 
        {
            var txtFName1 = (TextBox)((GridView)sender).FooterRow.FindControl("txtname2");
            if (txtname2 == null)
            {
                return;
            }
            string name = txtname2.Text;
        }
    }
