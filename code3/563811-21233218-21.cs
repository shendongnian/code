	protected void Page_Load(object sender, EventArgs e)
	{
	    GridViewHelper helper = new GridViewHelper(this.GridView1);
	    string[] cols = new string[2];
	    cols[0] = "ShipRegion";
	    cols[1] = "ShipName";
	    helper.RegisterGroup(cols, true, true);
	    helper.RegisterSummary("ItemTotal", SummaryOperation.Avg, "ShipRegion+ShipName");
	    helper.GroupSummary += new GroupEvent(helper_GroupSummary);
	    helper.ApplyGroupSort();
	}
	
	private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
	{
	    row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
	    row.Cells[0].Text = "Average";
	}
