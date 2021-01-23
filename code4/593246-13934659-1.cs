    foreach (PlacePhoneDTO placePhoneDTO in placePhoneList)
    {
        dbCommand = factory.CreateCommand();
        dbCommand.Connection = dbConnection.DbConnection;
        dbCommand.Transaction = dbTransaction;  
        dbCommand.CommandText = sqlStatementPhone.ToString();
        // Adds the parameters
        AddParameter<int>("@PlaceID", placeID, ref dbCommand);
        AddParameter<string>("@PhoneNumber", placePhoneDTO.phoneNumber, ref dbCommand);
        dbCommand.ExecuteNonQuery();
    }
