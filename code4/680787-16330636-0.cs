    const string news = "news";
    const string status = "status";
    const string notCompleted = "'NOT COMPLETED'";
    
    DataSet ds = new DataSet();
    ds.Tables.Add(news);
    ds.Tables[news].Columns.Add(status);
    ds.Tables[news].Rows.Add("test");
    ds.Tables[news].Rows.Add(notCompleted);
    ds.Tables[news].Rows.Add("dummy");
    IEnumerable<DataRow> dataRows = ds.Tables[news].Rows.Cast<DataRow>().Where(row => row[status].ToString() == notCompleted);
