    public List<Customer> ConsultCustomerData(string cardID)
    {
        const string query = "SELECT name, cash FROM customers WHERE card_id = @cardID";
        try
        {
            using(var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Customer>(query, new { cardID }).ToList();
            }
        }
        catch(Exception ex)
        {
            // Logging, etc..
            Console.Write(ex.ToString());
            throw; //Rethrow exception
        }
    }
