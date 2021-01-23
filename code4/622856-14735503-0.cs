    protected void YourRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
            if (ListItemType.Item == e.Item.ItemType || ListItemType.AlternatingItem == e.Item.ItemType)
            {
              var lbl = (Label)e.Item.FindControl("lblName");
    		  if(lbl.Text == "something")
    			lbl.CssClass = "someCssClass";
    		}
    }
