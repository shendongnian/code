    public int GetStockQuantity(string product)
    {
        int quantity = 0;
        string sql = "SELECT TOP 1 [Quantity] FROM [Product] WHERE [Product Name] = ?";
        using(var oleConn = new OleDbConnection(connString))
        using(var cmd = new OleDbCommand(sql , oleConn))
        {
            cmd.Parameters.AddWithValue("?", product);
            try
            {
                oleConn.Open();
                object obj_quantity = cmd.ExecuteScalar();
                if(obj_quantity != null)
                    quantity = (int) obj_quantity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        return quantity;
    }
