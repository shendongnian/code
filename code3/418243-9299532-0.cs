    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("id", Type.GetType("System.Int32"));
    dt.Columns.Add(dc);
    
    DataRow dr = dt.NewRow();
    dr["id"] = 1;
    dt.Rows.Add(dr);
    
    dr = dt.NewRow();
    dr["id"] = 1;
    dt.Rows.Add(dr);
