    using (SqlConnection dbConn = new SqlConnection(connectionString))
    {
        dbConn.Open();
        using (SqlCommand dbCommand = new SqlCommand("insert into [DB].[dbo].[User] ( [Id], [AccountId], [FirstName], [LastName], [JobTitle], [PhoneNumber] ) values ( @id, @accountid, @firstname, @lastname, @jobtitle, @phonenumber );", dbConn))
        {
            dbCommand.Parameters.Add("id", SqlType.VarChar).Value = id;
            dbCommand.Parameters.Add("accountid", SqlType.VarChar).Value = accountId;
            dbCommand.Parameters.Add("firstname", SqlType.VarChar).Value = firstName;
            dbCommand.Parameters.Add("lastname", SqlType.VarChar).Value = lastName;
            dbCommand.Parameters.Add("jobtitle", SqlType.VarChar).Value = jobTitle;
            dbCommand.Parameters.Add("phonenumber", SqlType.VarChar).Value = phoneNumber;
            dbCommand.ExecuteNonQuery();
        }
        dbConn.Close();
    }
