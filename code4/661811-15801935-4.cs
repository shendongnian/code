    static void Main()
    {
        var table = new DataTable();
        table.Columns.Add("Foo");
        table.Columns.Add("ID", typeof(int));
    	
        for (int i = 0; i < 100; i++)
        {
            table.Rows.Add(i.ToString(), i);
        }
        for (int j = 0; j < 100; j++) 
        {
            Enumerable
               .Range(0,100)
               .AsParallel()
               .ForAll(item => ExecuteToTable(table, item));
        }
    }
    static void ExecuteToTable(DataTable table, int item)
    {
        var view = table.DefaultView;
        view.RowFilter = string.Format("Foo = '{0}'", item);
        var filteredTable = view.ToTable();
    }
