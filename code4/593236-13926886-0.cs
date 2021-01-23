    DataSet ds;
    try
    {
    ds = new DataSet();
    ds = DataProvider.Connect_Select(strSql);
    string Title = ds.Tables[0].Rows[0]["Article_Title"].ToString();
    string Desc = ds.Tables[0].Rows[0]["Article_Desc"].ToString();
    }
    finally 
    {
    if(ds != null)
         ds.Dispose();
    }
