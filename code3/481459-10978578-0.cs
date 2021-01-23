    using (SqlDataReader reader = com.ExecuteReader())
    {
        int userOrd = reader.GetOrdinal("users");
        while (reader.Read())
        {
            string username = reader.GetString(userOrd);
        }
    }
