            public void WriteRecord(String sUsername, String sPassword, Boolean boEngineerRole, Boolean boDefaultUser)
           {
            String InsertQry = "Insert into Security([Username], [Password], [Engineer], [Default]) "
                + "values(@UserName, @Password, @Engineer, @Default)";
            using (OleDbConnection connection = new OleDbConnection(SecurityDBConnection))
            {
               using (OleDbCommand command = new OleDbCommand(InsertQry, connection))
               {
                   command.CommandType = CommandType.Text;
                   command.Parameters.AddWithValue("@UserName", sUsername);
                   command.Parameters.AddWithValue("@Password", sPassword);
                   command.Parameters.AddWithValue("@Engineer", boEngineerRole);
                   command.Parameters.AddWithValue("@DefaultUser", boDefaultUser);
                   connection.Open();
                   command.ExecuteNonQuery();
               }
            }
        }
