    Stopwatch SwSqlMdfLocalDb11 = new Stopwatch();
    SwSqlMdfLocalDb11.Start();
    NewDtForIns.BeginLoadData();
    
    for (int i = 0; i < 1000000; i++)
    {
       NewDtForIns.LoadDataRow(new object[] { null, "NewShipperCompanyName", "NewShipperPhone" }, false);
    }
    
     NewDtForIns.EndLoadData();
     DBRCL_SET.UpdateDBWithNewDtUsingSQLBulkCopy(NewDtForIns, tblClients._TblName);
     SwSqlMdfLocalDb11.Stop();
