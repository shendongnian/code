    static void GetSalesByCategory(string connectionString,string categoryName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create the command and set its properties.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            
            command.CommandText = "SalesByCategory";       
            command.CommandType = CommandType.StoredProcedure;
    
            // Add the input parameter and set its properties.
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CategoryName";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = categoryName;
    
            // Add the parameter to the Parameters collection. 
            command.Parameters.Add(parameter);
    
            // Open the connection and execute the reader.
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
    
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
    }
