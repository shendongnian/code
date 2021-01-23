    protected void UserPostRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)  // Add this
        {
         Label label = e.Item.FindControl("TextLabel") as Label;
         string text = label.Text;
        }
    }
