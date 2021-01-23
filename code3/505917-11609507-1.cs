    public void repeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Label lblQuestion = (Label)e.Item.FindControl("lblQuestion");
            Label lblAnswer = (Label)e.Item.FindControl("lblAnswer");
            //Your logic for getting the questions and answers per iteration
        }
    }
        
