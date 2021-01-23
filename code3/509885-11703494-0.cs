    System.Data.DataTable dt = new System.Data.DataTable();
    dt.Load(myDataReader);
    int recordCount = dt.Rows.Count;
    if(recordCount > 0)
    {
       if(dt.Rows[recordCount-1]["username"] == "wrong value")
         throw new Exception("wrong value");
    }
