    using (mySqlConnection = new SqlConnection())
    {
        mySqlConnection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connectionstring"].ToString();
    
        using (mySqlCommand = new SqlCommand("spSocialGetUniqueWords", mySqlConnection))
        {
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlConnection.Open();
            foreach (KeyValuePair<string, int> pair in url)
            {
                mySqlCommand.Parameters.Clear();
 
                mySqlCommand.Parameters.Add(
                    new SqlParameter("@uniqueKeyWords", pair.Key));
    
                mySqlCommand.Parameters.Add(
                    new SqlParameter("@counts", pair.Value));
                count = mySqlCommand.ExecuteNonQuery();  
            }
        }
    }
