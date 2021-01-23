    public int GetStockQuantity(string product)
    {
        int quantity = 0;
        string sql = "SELECT [Quantity] FROM [Product] WHERE [Product Name] = ?";
        using(var oleConn = new OleDbConnection(connString))
        using(var cmd = new OleDbCommand(sql , oleConn))
        {
            cmd.Parameters.AddWithValue("?", product);
            try
            {
                oleConn.Open();
                quantity = (int) cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        return quantity;
    }
