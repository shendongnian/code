    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
        DropDownList cbo = (DropDownList)e.Item.FindControl("cboType");
        for (int i = 0; i < cbo.Items.Count; i++)
        {
            Behaviour b = (Behaviour)e.Item.DataItem;
            if (b.Type_of_Behaviour == cbo.Items[i].Value)
                cbo.Items[i].Selected = true;
            else
                cbo.Items[i].Selected = false;
        }
    }
