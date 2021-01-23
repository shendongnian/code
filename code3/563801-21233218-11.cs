	protected void Page_Load(object sender, EventArgs e)
	{
	    GridViewHelper helper = new GridViewHelper(this.GridView1);
	    helper.RegisterGroup("ShipRegion", true, true);
	    helper.RegisterGroup("ShipName", true, true);
	    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum, "ShipName");
	    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum);
	    helper.GroupSummary += new GroupEvent(helper_Bug);
	    helper.ApplyGroupSort();
	}
	
	private void helper_Bug(string groupName, object[] values, GridViewRow row)
	{
	    if (groupName == null) return;
	
	    row.BackColor = Color.Bisque;
	    row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
	    row.Cells[0].Text = "[ Summary for " + groupName + " " + values[0] + " ]";
	}
 
