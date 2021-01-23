    public void lv1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType != ListViewItemType.DataItem)
        {
            return;
        }
        KeyValuePair<string, string> idWithText = 
            (KeyValuePair<string, string>)e.Item.DataItem;
        Button myButton = e.Item.FindControl("btn1") as Button;
        myButton.Text = idWithText.Value;
    }
