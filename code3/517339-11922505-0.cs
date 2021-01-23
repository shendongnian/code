    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        // Get the Link Button which has been clicked.
        LinkButton btn = (LinkButton)sender;
        // Get the DataListItem in the DataList which contains the LinkButton which was clicked.
        DataListItem listItem = (DataListItem)btn.NamingContainer;
        // Get the ItemIndex of the DataListItem.
        int itemIndex = listItem.ItemIndex;
        // Find the asp:Panel in the DataListItem of the DataList (e.g. DataList1).
        Panel currentPanel = (Panel)DataList1.Items[itemIndex].FindControl("DivContent");
    }
