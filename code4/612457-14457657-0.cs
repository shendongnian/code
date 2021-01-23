    void Main() 
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        dt.Columns.Add(new System.Data.DataColumn("Test", typeof(System.String)));
        var row = dt.NewRow();
        row["Test"] = "1";
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["Test"] = "2";
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["Test"] = "3";
        dt.Rows.Add(row);
	
        Console.WriteLine("Order before Remove/InsertAt");
        foreach(System.Data.DataRow rw in dt.Rows)
        {
            Console.WriteLine(rw["Test"]);
        }
	
        var lastRow = dt.Rows[dt.Rows.Count - 1];
        var newFirstRow = dt.NewRow();
        newFirstRow.ItemArray = lastRow.ItemArray;
        dt.Rows.Remove(lastRow);
        dt.Rows.InsertAt(newFirstRow, 0);
        Console.WriteLine("Order after Remove/InsertAt");
        foreach(System.Data.DataRow rw in dt.Rows)
        {
            Console.WriteLine(rw["Test"]);
        }
    }
