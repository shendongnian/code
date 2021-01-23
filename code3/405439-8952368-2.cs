    private const string GetUserByIdSql =
        "Select Name, Email, LastLogin, FK_Role_ID from Users where ID=@id";
    public static Users GetByID(int ID, SqlConnection connection)
    {
        var sql = ;
        Users user;
        int roleId;
        using (var command = new SqlCommand(GetUserByIdSql, connection))
        {
            command.Parameters.Add(new SqlParameter("id", ID));
            using (var reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return null;
                }
                user = new Users
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
