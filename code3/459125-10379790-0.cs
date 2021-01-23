    void LoadmyHashTable()
    {
      
        bussinessObject bs = new bussinessObject();
        DataSet ds = new DataSet();
        ds = bs.GetPosType(-1);      
        if (ds.Tables.Count > 0 )
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count-1; i++)
            {
                myHashTable.Add(ds.Tables[0].Rows[i]["dTypeId"], ds.Tables[0].Rows[i]["dTypeName"]);
            }
        }
       
    }
