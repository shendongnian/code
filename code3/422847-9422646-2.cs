    foreach (RepeaterItem item1 in ParentRepeater.Items)
    {
        if (item1.ItemType == ListItemType.Item || item1.ItemType == ListItemType.AlternatingItem)
        {
            ChildRepeater = (Repeater)item1.FindControl("ChildRepeater");
            foreach (RepeaterItem item2 in ChildRepeater.Items)
            {
                if (item2.ItemType == ListItemType.Item || item2.ItemType == ListItemType.AlternatingItem)
                {
                     TextBox txt = (TextBox)item2.FindControl(("TextBox1")) as TextBox;
                }
            }
        }
    }
