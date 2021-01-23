    public class PeopleRepository
    {
        public IList<Person> Get()
        {
            var connectionString = ConfigurationManager
                .ConnectionString["SomeConnectionStringKey"]
                .ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT id, fname, lname, ssn FROM people";
                using (var reader = cmd.ExecuteReader())
                {
                    var result = new List<Person>();
                    while (reader.Read())
                    {
                        result.Add(new Person
                        {
                            Id = reader.GetInt32(reader.GetOrindal("id")),
                            FirstName = reader.GetString(reader.GetOrindal("fname")),
                            LastName = reader.GetString(reader.GetOrindal("lname")),
                            SocialSecurity = reader.GetString(reader.GetOrindal("ssn"))
                        });
                    }
                    return result;
                }
            }
        }
    
        public void Delete(int id)
        {
            var connectionString = ConfigurationManager
                .ConnectionString["SomeConnectionStringKey"]
                .ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "DELETE FROM people WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
