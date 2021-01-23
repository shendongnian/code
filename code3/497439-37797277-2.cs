    class ComplexData
    {
    	public int Value { get; set; }
    }
    
    class ComplexDataWrapper
    {
    	public string Name { get; set; }
    	public ComplexData Data { get; set; } = new ComplexData();
    }
    
    static class Program
    {
    	[STAThread]
    	static void Main()
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		var form = new Form();
    		var gridView = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    		gridView.DataSource = ListDataView.Create(GetData(), null, p =>
    		{
    			if (p.PropertyType == typeof(ComplexDataWrapper))
    				return ChildPropertyDescriptor.Create(p, "Name", "Complex Name");
    			return p;
    		});
    		Application.Run(form);
    	}
    
    	static DataTable GetData()
    	{
    		var dt = new DataTable();
    		dt.Columns.Add("Id", typeof(int));
    		dt.Columns.Add("Complex", typeof(ComplexDataWrapper));
    		for (int i = 1; i <= 10; i++)
    			dt.Rows.Add(i, new ComplexDataWrapper { Name = "Name#" + i, Data = new ComplexData { Value = i } });
    		return dt;
    	}
    }
