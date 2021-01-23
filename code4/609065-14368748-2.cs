    static IEnumerable<Admin> GetAdminsByUsername(SqlConnection connection, 
                                                  string username)
    {
      var adminList = new List<Admin>();
      // You really should be using stored procedures here instead...
      var query = @"SELECT * FROM Admins WHERE Username = @Username";
      using (var command = new SqlCommand(query, connection))
      {
        command.Parameters.AddWithValue("@Username", username);
        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            var adminUsername = reader["Username"].ToString();
            var adminDepartment = reader["Department"].ToString();
            var admin = new Admin
            {
              Username = adminUsername,
              Department = adminDepartment
            };
            adminList.Add(admin);
          }
          reader.Close();
          return adminList;
        }
      }
    }
