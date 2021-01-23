    protected void rptDummy_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	long itemsCount = ((List<SomeClass>)rptDummy.DataSource).Count;
    
    	if (e.Item.ItemType == ListItemType.Item)
    	{ 
			PlaceHolder phIsLastOne = (PlaceHolder)e.Item.FindControl("phIsLastOne");
			PlaceHolder phIsNotLastOne = (PlaceHolder)e.Item.FindControl("phIsNotLastOne");
    		phIsLastOne.Visible = e.Item.ItemIndex == itemsCount - 1;
    		phIsNotLastOne.Visible = !this.phIsLastOne.Visible;
    	}
    }
