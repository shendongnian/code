    DataTable dt = new DataTable();
    dt.Columns.Add("Cost", typeof(string));
    dt.Rows.Add(new object[] { "1" });
    dt.Rows.Add(new object[] { "3.25" });
    dt.Rows.Add(new object[] { "0.75" });
    
    // temporary column for converting string to decimal
    dt.Columns.Add("CostNumeric", typeof(decimal), "Convert(Cost, 'System.Decimal')");
    // using temporary column to do aggregation
    object TotalCost = dt.Compute("Sum(CostNumeric)", "");
    
    dt.Columns.Remove("CostNumeric");
    Console.WriteLine(TotalCost);
