    dt.Columns.Add(new DataColumn("Ratio", typeof(double)));
    dt.Columns.Add(new DataColumn("Rank", typeof(int)));
    foreach (DataRow row in dt.Rows)
    {
        row["Ratio"] =
            (Convert.ToDecimal(row["LastMonth"]) / NoOfBranches).ToString("0.##");
    }
    //sorting the DataTable using the new DataColumn
    dt.DefaultView.Sort = "Ratio DESC";
    //after the sort, set the rank for each one
    int rank = 1;
    foreach (DataRow row in dt.Rows)
    {
        row["Rank"] = rank++;
    }
    
