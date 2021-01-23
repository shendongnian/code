     public class DB
    {
        string connString = "Your Database Connection String";
        public List<Product> GetProductsFromDatabase()
        {
            string query = "SELECT product, quantity FROM yourTable";
            List<Product> prodList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        // Create new Product
                        Product p = new Product();
                        p.ProductName = (String)reader[0];
                        p.Quantity = (Int32)reader[1];
                        // Add product to list
                        prodList.Add(p);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return prodList;
        }
    }
