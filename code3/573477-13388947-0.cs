    protected void SuperSimple_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //check the item type, headers won't contain the control
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //find the control and put it's value into a variable
            HiddenField hidID = (HiddenField)e.Item.FindControl("hidID");
            string strID = hidID.Value;
        }
    }
