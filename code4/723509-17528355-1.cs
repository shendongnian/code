    void Main()
    {
       DataRow[] rows = GetDataTable().Select("B='car'");
       rows.Dump();
    }
    
    // Define other methods and classes here
    
    private DataTable GetDataTable()
    {
       DataTable table = new DataTable("NameIsOptional");
       table.Columns.Add(new DataColumn("A", typeof(int)));
       table.Columns.Add(new DataColumn("B", typeof(string)));
       table.Columns.Add(new DataColumn("C", typeof(string)));
    
       table.Rows.Add(1000, "car", "new");
       table.Rows.Add(2000, "house", "old");
       table.Rows.Add(3000, "car", "newer car");
    	
       return table;
    }
