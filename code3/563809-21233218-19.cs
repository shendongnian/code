	protected void Page_Load(object sender, EventArgs e)
	{
	    GridViewHelper helper = new GridViewHelper(this.GridView1);
	    helper.RegisterGroup("ShipRegion", true, true);
	    helper.RegisterGroup("ShipName", true, true);
	    helper.GroupHeader += new GroupEvent(helper_GroupHeader);
	    helper.ApplyGroupSort();
	}
	    
	private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
	{
	    if ( groupName == "ShipRegion" )
	    {
	        row.BackColor = Color.LightGray;
	        row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
	    }
	    else if (groupName == "ShipName")
	    {
	        row.BackColor = Color.FromArgb(236, 236, 236);
	        row.Cells[0].Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + row.Cells[0].Text;
	    }
	}
