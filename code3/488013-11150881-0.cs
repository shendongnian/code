        SqlConnection conUpdate = new SqlConnection(GetConnectionString());
        conUpdate.Open();
        SqlCommand com2 = new SqlCommand();
        com2.Connection = conUpdate;
        com2.CommandType = CommandType.Text;
        com2.CommandText = "SELECT Students.StudentID, Users.UserID FROM Students, Users " +
            "WHERE Students.UserID = Users.UserID";
        SqlDataReader reader = com2.ExecuteReader();
        if(reader != null)
        {
            while(reader.Read())
            {
                SqlCommand com3 = new SqlCommand();
                com3.Connection = conUpdate;
                com3.CommandType = CommandType.Text;
                com3.CommandText = "UPDATE Users SET UserName=@UserName, Password=@Password WHERE UserID=@UserID";
                // Assuming that you need both the UserName and Password to default to StudentID
                com3.Parameters.AddWithValue("@UserName", reader.GetString(0)); // Assuming StudentID is NVARCHAR
                com3.Parameters.AddWithValue("@Password", reader.GetString(0)); // Assuming StudentID is NVARCHAR
                com3.Parameters.AddWithValue("@UserID", reader.GetString(1)); // Assuming UserID is NVARCHAR
                com3.ExecuteNonQuery();                
            }
            reader.Close();
        }
        conUpdate.Close();
