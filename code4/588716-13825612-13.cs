    private DataTable GetDbTable(DbTbl dbTbl, SProc Sprc)
    {
        SQLDBInteraction.DataContainer DC_Time = new SQLDBInteraction.DataContainer();
        //ParmsTime- a class instace, for passing a set of required parameters to final stage
        SQLDBInteraction.SqlParamList ParmsTime = new SQLDBInteraction.SqlParamList();
        
        ParmsTime.SqlCmd.CommandType = CommandType.StoredProcedure;
        //using the stored procedure struct:  assigend to Sqlcommand as its CommandText 
        ParmsTime.SqlCmd.CommandText = Sprc.Name;
        //using stored procedure parameters list - allso via a struct above codes
        ParmsTime.SqlCmd.Parameters.AddRange(Sprc.SpParList.ToArray());
        //using DataTable struct to assign the data table a name
        ParmsTime.TableName = dbTbl.Name;
        return DC_Time.LocalTbl_V3(ParmsTime);
    }
