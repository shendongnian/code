     public List<Customer> ConsultCustomerData(string cardID)
     {
        List<Customer> list = new List<Customer>();
        string sql = "SELECT name, cash FROM customers WHERE card_id = @cardID";        
        
        MySqlCommand cmd = new MySqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new MySqlParameter("@cardID", MySqlDbType.VarChar)).Value = cardID;
        using (IDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
                 list.Add(new Customer { 
                     Name = reader.GetString(0), 
                     Cash = reader.GetDouble(1) 
                 });
            }
        }
    } 
