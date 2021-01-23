    protected DataTable Data
    {
    	get
    	{
    		if (ViewState["Data"] == null)
    		{ 
    			DataTable table = new DataTable();
    			table.Columns.Add("ID", typeof(int));
    			table.Columns.Add("Name");
    			table.Columns.Add("Color");
    			table.Columns.Add("Weight", typeof(int));
    
    			table.Rows.Add(1, "Ball", "Red", 10);
    			table.Rows.Add(2, "Table", "Black", 50);
    			table.Rows.Add(3, "Chair", "Green", 30);
    			ViewState["Data"] = table;
    		}
    		return (DataTable)ViewState["Data"];
    	}
    }
