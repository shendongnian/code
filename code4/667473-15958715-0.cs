    protected void updatestatus(object sender, System.EventArgs e)
    {
        if (txtname.Text != String.Empty)
        {
            if (ddlStatus.Text.Trim() == "Waiting")
            {
               RadComboBoxItem item = ddlStatus.FindItemByText("complete");
               item.Selected = true;
            }
        }
    }   
