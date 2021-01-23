    protected void buttonResend_Click(object sender, EventArgs e)
    {
        List<Items> listOfSelectedItems = new List<Items>();
        // Put logic here for populating listOfSelectedItems
        // Store listOfSelectedItems in Session cache
        Session["SelectedItems"] = listOfSelectedItems;
    }
