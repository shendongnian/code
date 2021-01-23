    List<DataRow> rowsToRemove = new List<DataRow>();
    foreach (DataRow dr in resE1.Rows)
    {
        if(dr["SignalName"].ToString().Substring(0, 4) == "null")
        {
            dr.SetField<String>("SignalName", "");
        }
        bool hasValue = false;
        foreach (DataColumn dc in resE1.Rows[i].Columns)
        {
            if (!dr[dc.ColumnName].ToString().Equals(String.Empty))
               hasValue = true;
        }
        if (!hasValue) rowsToRemove.Add(dr);
    }
    foreach(dr in rowsToRemove)
    {
       dt.Delete();
    }
