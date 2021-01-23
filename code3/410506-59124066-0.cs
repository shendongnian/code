    public DataSet Getdatasettables()
    {
     DataSet ds = new DataSet();
     DataTable dt1 = new DataTable();
     DataTable dt2 = new DataTable();
     ds.Tables.Add(dt1);
     ds.Tables.Add(dt2);
     return ds;
    }
