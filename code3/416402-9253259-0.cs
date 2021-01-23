    void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            RadioButtonList rbl = (RadioButtonList)e.Item.FindControl["blah"];
            // do anything with your rbl
        }
    }    
