    protected void rptDummy_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		Block blk = (Block)e.Item.DataItem;
    		RadioButtonList list = new RadioButtonList();
    		list.ID = "rblBlocks";
    		list.Attributes.Add("BlockID", blk.ID.ToString());
    		foreach (string item in blk.BlockNames)
    		{
    			list.Items.Add(new ListItem(item, item));
    		}
    
    		e.Item.Controls.Add(list);
    	}
    }
