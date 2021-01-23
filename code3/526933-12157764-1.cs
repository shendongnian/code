    dt= ds.Tables[0].Clone();
    for (ICol = 0; ICol < ds.Tables[0].Columns.Count; ICol++)
        dt.Columns[ICol].DataType = typeof(string);
        foreach (DataRow row in ds.Tables[0].Rows) 
        {
            dt.ImportRow(row); 
    }
