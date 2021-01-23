	private List<int> mQuantities = new List<int>();
	
	protected void Page_Load(object sender, EventArgs e)
	{
	    GridViewHelper helper = new GridViewHelper(this.GridView1);
	    helper.RegisterSummary("Quantity", SaveQuantity, GetMinQuantity);
	}
	
	private void SaveQuantity(string column, string group, object value)
	{
	    mQuantities.Add(Convert.ToInt32(value));
	}
	
	private object GetMinQuantity(string column, string group)
	{
	    int[] qArray = new int[mQuantities.Count];
	    mQuantities.CopyTo(qArray);
	    Array.Sort(qArray);
	    return qArray[0];
	}
