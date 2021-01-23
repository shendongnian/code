    DataSet ds = new DataSet();
    addTables(dtbag101);
    addTables(dtwallet111); //ds will be merge of both tables here
-----
    private void addTables(DataTable dt)
    {
       for(int intCount = ds.Tables[0].Rows.Count; intCount < dt.Rows.Count;intCount++)
       {
           for(int intSubCount = 0;intSubCount < dt.Columns.Count; intSubCount++)
           {
              ds.Tables[0].Rows[intCount][intSubCount] = dt.Rows[intCount][intSubCount];
           }
       }
    }
