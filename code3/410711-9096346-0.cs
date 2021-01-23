    protected void rptCommentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            // get the data item
            MyObject myObject = (MyObject)e.Item.DataItem;
            // find the label
            Label lblComUserName = (Label)e.Item.FindControl("lblComUserName");
            // do the magic!
            if (myObject.comAnonymous)
                 lblComUserName.Visible = false;
        }
    }
