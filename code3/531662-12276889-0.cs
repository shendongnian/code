    protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item)
            {
                TextBox mytxt = e.Item.FindControl("txtWeekly") as TextBox;
                // you can just pass "this" instead of "mytxt.ClientID" and get the ID from the DOM element
                mytxt.Attributes.Add("onchange", "doStuff('" + mytxt.ClientID + "');");
            }
        }
