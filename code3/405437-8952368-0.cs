    public static Users GetByID(int ID, SqlConnection connection)
    {
        var sql = "Select Name, Email, LastLogin, FK_Role_ID from Users where ID=@id";
        Users user;
        int roleId;
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add(new SqlParameter("id", ID));
            using (var reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return null;
                }
                user = new User
                {
                    Name = reader.GetString(0),
                    Email = reader.GetString(1),
                    LastLogin = reader.GetString(2),
                };
                // Remember this so we can call GetRoleByID after closing the reader
                roleID = reader.GetInt32(3);
            }
        }
        user.Role = Role.GetRoleByID(roleID, connection);
        return user;
    }
