    foreach (KeyValuePair<int,string> kvp in Valuedescripts)
    {
        int val = kvp.Key;
        string descrip = kvp.Value;
    
        foreach (DataUds data in DataUds)
        {
            //something like
            if (descrip == data.item) //only u know it
            {
                using (DB2Connection sqlconn = new DB2Connection())
                {
                    sqlconn.Open();
    
                    DB2Command cmdtx = new DB2Command();
    
                    string insert = @"INSERT into LNPY (LN_NR, ITEM_NAME, MR_NR, VALUE)
                                      VALUES (@LN, @Nbr, @Val, @ValueDE)";
                    cmdtx.Parameters.Add("@Nbr", data.MN);
                    cmdtx.Parameters.Add("@Ln", data.LN);
                    cmdtx.Parameters.Add("@Val",data.item);
                    cmdtx.Parameters.Add("@ValueDE", val);
                    break;
                 }
            }  
        }
    }
