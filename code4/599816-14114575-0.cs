    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        // note the ListViewItemType.InsertItem !!!
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            TextBox OpenDateTextBox = (TextBox)e.Item.FindControl("OpenDateTextBox");
            OpenDateTextBox.Text = "12/12/2012";
        }
    }
