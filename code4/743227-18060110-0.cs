    foreach (KeyValuePair<string, int> pair in url)
    {
        mySqlCommand.Parameters.Clear();
        
        mySqlCommand.Parameters.Add(
        new SqlParameter("@uniqueKeyWords", pair.Key));
    
        mySqlCommand.Parameters.Add(
        new SqlParameter("@counts", pair.Value));
    
        mySqlCommand.CommandType = CommandType.StoredProcedure;
        mySqlCommand.Connection.Open();
        count = mySqlCommand.ExecuteNonQuery();
        mySqlCommand.Connection.Close();          
    }
