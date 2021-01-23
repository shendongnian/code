    protected void rpConditionRadioButtons_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater innerRepeater = (Repeater)sender;
            RepeaterItem outerItem = (RepeaterItem)innerRepeater.NamingContainer;
            Label lblAccID = (Label)outerItem.FindControl("lblAccID");
            RadioButton rbCondition = (RadioButton) e.Item.FindControl("rbCondition");
            rbCondition.GroupName = "gCondition_" + lblAccID.Text;
        }
    }
