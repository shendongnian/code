    protected void repeaterID_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		ListView listView = e.Item.FindControl("listViewID") as ListView;
    		TextBox textBox = listView.FindControl("textBoxID") as TextBox;
    		textBox.Text = listView.StringYoureLookingFor;
    	}
    }
