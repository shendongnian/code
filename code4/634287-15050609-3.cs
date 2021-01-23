    protected void rptDummy_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	long itemsCount = ((List<SomeClass>)rptDummy.DataSource).Count;
    
    	if (e.Item.ItemType == ListItemType.Item)
    	{ 
    		this.phIsLastOne.Visible = e.Item.ItemIndex == itemsCount - 1;
    		this.phIsNotLastOne.Visible = !this.phIsLastOne.Visible;
    	}
    }
