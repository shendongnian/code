    public bool removeStock(string user_name,string stock_symbol) 
    { 
        user_name = user_name.Trim(); 
        stock_symbol = stock_symbol.Trim(); 
        string statement = "DELETE FROM users_stocks " + 
                            "WHERE user_name = @name AND stock_symbol = @stock" ; 
        SqlCommand cmdnon = new SqlCommand(statement, connection); 
        try 
        { 
            cmdnon.Parameters.AddWithValue("@name", user_name);
            cmdnon.Parameters.AddWithValue("@stock", stock_symbol);
            connection.Open(); 
            int num = cmdnon.ExecuteNonQuery(); 
            connection.Close(); 
            return true; 
        } 
        catch (SqlException ex) 
        { 
            Console.WriteLine(ex.ToString()); 
            connection.Close(); 
            return false; 
        } 
    } 
