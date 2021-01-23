    foreach (ListItem chk in cblProducts.Items)
    {
        string productId= chk.Value;
        if (IsProductAvailable(productId) // this method will basically goes to database and return true of false
            chk.Selected = true;
        else
            chk.Selected = false;
    }
 
    private void IsProductAvailable(string productId)
    {
            string query = "SELECT [ProductId] FROM [Product] ";
            query += "WHERE [ProductId] = @ProductId";
            DbCommand comm = new DbCommand();
            comm.CommandText = query;
    
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ProductId";
            param.Value = productId;
            comm.Parameters.Add(param);
    
            DataTable table = comm.ExecuteCommand();
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
    }
