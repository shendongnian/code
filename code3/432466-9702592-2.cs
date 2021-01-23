    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList cbo = (DropDownList)e.Item.FindControl("cboType");
            Behaviour b = (Behaviour)e.Item.DataItem;
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (b.Type_of_Behaviour == cbo.Items[i].Value)
                    cbo.Items[i].Selected = true;
                else
                    cbo.Items[i].Selected = false;
            }
        }
    }
