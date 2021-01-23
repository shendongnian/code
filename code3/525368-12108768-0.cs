    DataTable dtResult= new DataTable();
    
    dtSession = objOpt.GetSearchDetails().Copy();
    dtSession.TableName = "B";
    ds.Tables.Add(dtSession);
    
    
    dtResult = objOpt.Search_Synchronous().Copy();
    dtResult.TableName = "A";
    ds.Tables.Add(dtResult);
