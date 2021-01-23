    while (objSqlDataReader.Read())
    {
       data= new data();
       if (!objSqlDataReader.IsDBNull(objSqlDataReader.GetOrdinal("EFID")))
       {
          emissiondata.ID = (int)objSqlDataReader["EFID"];
       } else {
          // Whatever you want to do when it is null
       }
       if (!objSqlDataReader.IsDBNull(objSqlDataReader.GetOrdinal("EFMappingID")))
       {
          emissiondata.Map = (int)objSqlDataReader["EFMappingID"];
       } else {
          // Whatever you want to do when it is null
       }
       if (!objSqlDataReader.IsDBNull(objSqlDataReader.GetOrdinal("MobileTypeID")))
       {
          emissiondata.TypeID = (int)objSqlDataReader["MobileTypeID"];
       } else {
          // Whatever you want to do when it is null
       }
    }
