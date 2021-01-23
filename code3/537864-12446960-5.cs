    class Program 
    {
        static void Main(string[] args) 
        {
            var models = SelectTop100Models("SELECT top 100 * FROM x");
            //do other stuff
        }
        static IEnumerable<MyModel> SelectTop100Models() 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["XXX"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT top 100 * FROM x";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new MyModel
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        };
                    }
                }
            }
        }
    }
