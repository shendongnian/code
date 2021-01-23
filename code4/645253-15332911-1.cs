    public static int Login(string user, string password)
    {
        using (var conn = new SqlConnection(GetConnectionString()))
        {
            conn.Open();
            string sql = "select Id, PasswordHash from logins where Username=@Username";
            using (var command = new SqlCommand(sql))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user;
                using (var reader = command.ExecuteRead())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string hash = reader.GetString(1);
                        // TODO: Hash provided password with the same salt and compare
                        // results
                        if (CheckPassword(password, hash))
                        {
                            return id;
                        }
                    }
                    return 0; // Or use an int? return type and return null
                }
            }
        }
    }
