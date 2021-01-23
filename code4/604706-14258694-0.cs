    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable results = new DataTable();
    dt1.Columns.Add("Name");
    dt1.Columns.Add("cost", typeof(int));
    dt2.Columns.Add("Name");
    dt2.Columns.Add("cost", typeof(int));
    results.Columns.Add("Name");
    results.Columns.Add("cost", typeof(int));
    dt1.Rows.Add("balan", 6);
    dt2.Rows.Add("balan", 2);
    dt1.Rows.Add("gt", 5);
    dt2.Rows.Add("gt", 8);
    foreach (DataRow dr1 in dt1.Rows)
    {
        results.Rows
            .Add(
                dr1["Name"], 
                (int)dr1["cost"] + (int)dt2.Select(String.Format("Name='{0}'", dr1["name"]))[0]["cost"]
            );
    }
