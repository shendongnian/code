	public DataTable MyDataTable { get; private set; }
	//ctor
	_ds = new DataSet("Test");
	this.MyDataTable = _ds.Tables.Add("DT");
	this.MyDataTable.Columns.Add("First");
	this.MyDataTable.Columns.Add("Second");
	this.MyDataTable.Rows.Add("11", "12");
	this.MyDataTable.Rows.Add("21", "22");
	//view is updated with this
	public void UpdateTable()
	{
		this.MyDataTable.Rows[0][1] = "haha";
	}
