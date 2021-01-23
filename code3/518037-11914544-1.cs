    resultDataTable.Columns.Add(new DataColumn("DateTime", typeof(DateTime)));
    foreach (DataRow r in dt.Rows)
    {
        r["DateTime"] = new DateTime(Convert.ToInt32(r["Timestamp"]);
    }
    dt.Columns.Remove("Timestamp");
