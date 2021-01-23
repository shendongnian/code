    dbCommand.CommandText = sqlStatementPhone.ToString();
    foreach (PlacePhoneDTO placePhoneDTO in placePhoneList)
    {
        dbCommand.Parameters.Clear();
        // Adds the parameters
        AddParameter<int>("@PlaceID", placeID, ref dbCommand);
        AddParameter<string>("@PhoneNumber", placePhoneDTO.phoneNumber, ref dbCommand);
        dbCommand.ExecuteNonQuery();
    }
