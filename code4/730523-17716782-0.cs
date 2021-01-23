    using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "Select name from dbo.product(nolock) Where product_no = @product_no";
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@product_no", ID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                prod.name          = reader["name"].ToString();
            }
        }
