    dt.Columns.Add(new DataColumn("ratio", typeof(double)));
    foreach (DataRow row in dt.Rows)
    {
        row["Ratio"] =
            (Convert.ToDecimal(row["LastMonth"]) / NoOfBranches).ToString("0.##");
    }
    //sorting the DataTable using the new DataColumn
    dt.DefaultView.Sort = "Ratio ASC";
