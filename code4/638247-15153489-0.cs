    public void UpdateStock()
    {
        foreach (var listBoxItem in listBox1.Items)
        {
            string result = Update(listBoxItem.ToString());
        }
    }
    public string Update(string product)
    {
        // Create connection object
        string rTurn = "";
        OleDbConnection oleConn = new OleDbConnection(connString);
        try
        {
            oleConn.Open();
            string sql = "UPDATE [Product] SET [Quantity]=[Quantity] - 1 WHERE [Product Name] = @product";
            OleDbCommand oleComm = new OleDbCommand(sql, oleConn);
            oleComm.Parameters.Add("@product", OleDbType.VarChar).Value = product;
            oleComm.ExecuteNonQuery();
            
            rTurn = "Stock Updated";    
        }
        catch (Exception ex)
        {
            rTurn = "Update Failed";
        }
        finally
        {
            oleConn.Close();
        }
        return rTurn;
    }
