    DataTable dt = new DataTable();
    //Populate Dt with SQL
    var tableInts = dt.Rows.Cast<DataRow>().Select(row => row.Field<int>("ID"));
    var allInts = IEnumerable.Range(0, tableInts.Max());
    var minInt = allInts.Except(allInts).Min();
