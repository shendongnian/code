    using (SqlConnection connection = new ...))
    {
       connection.Open();
       SqlCommand select = new SqlCommand(...);
    
       SqlDataReader reader = select.ExecuteReader();
    
       var toInactivate = new List<string>();
       if (reader.HasRows)
       {
          while (reader.Read())
          {
             if (!currentPart.IsActive)
             {
                toInactivate.Add(reader["record"].ToString());
             }
             else
             {
                ///blah
             }
          }
    
          reader.Close();
       }
       SqlCommand update = new SqlCommand("UPDATE ... SET valid = 0, active = 0 " +
           "WHERE record IN(" + string.Join(",", toInactivate) +  ");", connection);
    
       update.ExecuteNonQuery();
    }
