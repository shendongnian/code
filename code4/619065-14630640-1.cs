    DataTable dt = new DataTable();
    //Populate Dt with SQL
    var tableInts = dt.Rows.Cast<DataRow>().Select(row => row.Field<int>("ID")).ToList<int>();
    var allInts = Enumerable.Range(1, tableInts.Max()).ToList();
    var minInt = allInts.Except(tableInts).Min();
