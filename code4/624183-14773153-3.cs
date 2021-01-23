    DataSet ds = new DataSet();
    ds.Tables.Add(GetData());
    
    
    public datatable Sample GetData()
    {
    ......
    .......
    
    return ds.Tables["DSDummy"];
    }
