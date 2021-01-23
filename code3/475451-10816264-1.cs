    using (SqlDataReader objSqlDtReader = objDtAccess.GetDataReader()) 
    {
        while(objSqlDtReader.Read()) 
        {
            UserEntitie objUserEntitie = new UserEntitie();
            objUserEntitie.FillFromSqlDataReader(objSqlDtReader);
            /* Add to a list or something */    
        }
    }
