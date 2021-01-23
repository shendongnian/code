    public class MySQLProductRepository: IProductRepository
    {
        private readonly string _connectionString;
        public MySQLProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public Product Get(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT name FROM products WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
    
                    return new Product
                    {
                        Id = id,
                        Name = reader.GetString(reader.GetOrdinal("name"))
                    };
                }
            }
        }
    }
