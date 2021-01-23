    public IEnumerable<Favorites> GetFavorites()
    {
        using (SqlConnection sqlConnection = new SqlConnection(connString))
        {
            sqlConnection.Open();
            using (SqlCommand cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = "Select * from favorites";
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Create a Favorites instance
                        var favorites = new Favorites();
                        favorites.Foo = reader["foo"];
                        // ... etc ...
                        yield return favorites;
                    }
                }
            }
        }
    }
