    using (OleDbConnection cnn = new OleDbConnection(ConnectionString)) {
        string query = "SELECT ... FROM users LEFT JOIN user_roles ON ... ORDER BY UserID";
        using (OleDbCommand cmd = new OleDbCommand(query, cnn)) {
            cnn.Open();
            using (OleDbDataReader reader = cmd.ExecuteReader()) {
                int userIdOrdinal = reader.GetOrdinal("UserID");
                int userNameOrdinal = reader.GetOrdinal("UserName");
                int roleIdOrdinal = reader.GetOrdinal("RoleID");
                int roleNameOrdinal = reader.GetOrdinal("RoleName");
                User user = null;
                while (reader.Read()) {
                    int userID = reader.GetInt32(userIdOrdinal);
                    if (user == null || user.ID != userID) {
                        user = new User { ID = userID };
                        user.Name =  reader.GetString(userNameOrdinal);
                        _users.Add(user);
                    }
                    if (!reader.IsDBNull(roleIdOrdinal)) {
                        user.Roles.Add(reader.GetString(roleNameOrdinal);
                    }
                }
            }
        }
    }
