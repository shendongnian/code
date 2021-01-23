    public List<UserInfo> GetAllUsers()
    {
        List<UserInfo> users = new List<UserInfo>();
        try
        {
            using (SqlConnection sqlConnection = connectionString)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.GetAllUsers";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                UserInfo user = new UserInfo();
                                PropertyInfo[] pList = typeof(UserInfo).GetProperties();
                                foreach (PropertyInfo pi in pList)
                                {
                                    object value = dataReader[pi.Name];
                                    if (!value.GetType().Equals(typeof(DBNull)))
                                    {
                                        users.GetType().GetProperty(pi.Name, BindingFlags.Public | BindingFlags.Instance).SetValue(user, value, null);
                                    }
                                }
                                users.Add(user);
                            }
                        }
                        else
                        {
                            users = null;
                        }
                    }
                }
                sqlConnection.Close();
            }
        }
        catch (Exception)
        {
            return null;
        }
        return users;
    }
