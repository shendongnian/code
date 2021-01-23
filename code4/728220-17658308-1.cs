    protected void YourListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label theTWALabel = (Label)e.Item.FindControl("TWALabel");
            int theTWAValue = Convert.ToInt32(theTWALabel.Text);
            if (theTWAValue >= 85)
            {
                if (theTWAValue < 90)
                {
                    theTWALabel.CssClass = "YellowThis";
                }
                else
                {
                    theTWALabel.CssClass = "RedThis";
                }
            }
        }
    }
