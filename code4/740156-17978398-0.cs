    // Build a data table and add columns
    DataTable dt = new DataTable();
    dt.Columns.Add("IDRank");
    dt.Columns.Add("Blah");
    // Add rows to the table
    for (int i = 1; i < 5; i++) {
        DataRow dr = dt.NewRow();
        dr["IDRank"] = i;
        dr["Blah"] = "Blah" + i.ToString();
        dt.Rows.Add(dr);
    }           
    // Get a DataView to table
    DataView dv = dt.AsDataView();
    // Define the filter
    string filter = "IDRank = 2";
    // Apply the filter
    dv.RowFilter = filter;
    // Run the query
    var Query1 = from P in dv.ToTable().AsEnumerable() select P;
