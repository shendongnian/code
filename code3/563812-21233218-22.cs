	protected void Page_Load(object sender, EventArgs e)
	{
	    GridViewHelper helper = new GridViewHelper(this.GridView1);
	    helper.SetSuppressGroup("ShipName");
	    helper.RegisterSummary("Quantity", SummaryOperation.Sum, "ShipName");
	    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum, "ShipName");
	    helper.ApplyGroupSort();
	}
 
