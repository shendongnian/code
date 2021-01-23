    var dt = new DataTable();
    dt.Columns.Add("AsString", typeof(string));
    dt.Columns.Add("AsDateTime", typeof(DateTime));
    var now = DateTime.Now;
    var row = dt.Rows.Add(now.ToString(), now);
    row.Field<string>("AsString");     // this is fine
    row.Field<string>("AsDateTime");   // InvalidCastException: Unable to cast object of type 'System.DateTime' to type 'System.String'.
    row.Field<DateTime>("AsString");   // InvalidCastException: Specified cast is not valid.
    row.Field<DateTime>("AsDateTime"); // this is fine
    DateTime.Parse(row.Field<string>("AsString")); // this is fine
