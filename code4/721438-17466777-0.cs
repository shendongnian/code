    public static void Update(Resident resident, SqlConnection connection, SqlTransaction transaction, bool updateOnlyAdditionalInformation)
    {
        StringBuilder sqlString = new StringBuilder();
        SqlCommand command;
    
        sqlString.Append("UPDATE [Resident] SET ");
        
        if (!updateOnlyAdditionalInformation)
        {
          sqlString.Append("title = @title, ");
          sqlString.Append("firstName = @firstName, ");
          sqlString.Append("surname = @surname, ");
          sqlString.Append("dateOfBirth = @dateOfBirth, ");
          sqlString.Append("photo = @photo, ");
          sqlString.Append("doctorID = @doctorID, ");
          sqlString.Append("roomID = @roomID, ");
          sqlString.Append("allergies = @allergies, ");
        }
    
        sqlString.Append("additionalInformation = @additionalInformation ");
        sqlString.Append("WHERE residentID = @residentID ");
        command = new SqlCommand(sqlString.ToString(), connection);
        if ((transaction != null)) command.Transaction = transaction;
    
        command.Parameters.Add("@residentID", SqlDbType.Int).Value = resident.ResidentID;
        command.Parameters.Add("@additionalInformation", SqlDbType.NText).Value = resident.addtionalInformation;
        
        if (!updateOnlyAdditionalInformation)
        {
          command.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = Helper.GetValue(resident.Title);
          command.Parameters.Add("@firstName", SqlDbType.VarChar, 100).Value = Helper.GetValue(resident.FirstName);
          command.Parameters.Add("@surname", SqlDbType.VarChar, 100).Value = Helper.GetValue(resident.Surname);
          command.Parameters.Add("@dateOfBirth", SqlDbType.DateTime).Value = Helper.GetValue(resident.DateOfBirth);
          command.Parameters.Add("@photo", SqlDbType.Image, 2147483647).Value = Helper.GetValue(resident.Photo);
          command.Parameters.Add("@doctorID", SqlDbType.Int).Value = resident.Doctor.DoctorID;
          command.Parameters.Add("@roomID", SqlDbType.Int).Value = resident.Room.RoomID;
          command.Parameters.Add("@allergies", SqlDbType.NText).Value = resident.Allergies;
        }
    
        int rowsAffected = command.ExecuteNonQuery();
    
        if (!(rowsAffected == 1))
        {
            throw new Exception("An error has occurred while updating Resident details.");
        }
    }
