    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
       connection.Open();
       SqlCommand select = new SqlCommand("SELECT RTRIM(LTRIM(PART_NO)) AS PART_NO, record FROM [RMAData].[dbo].[IMPORTING_ORDER_EDI] WHERE sessionID = '" + Session.SessionID + "'", connection);
       SqlDataReader reader = select.ExecuteReader();
        
       if (reader.HasRows)
       {
          while (reader.Read())
          {
             if (!currentPart.IsActive)
             {
                // this part is not active, set the active flag in sql to 0
                using (SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
               {
                   SqlCommand update = new SqlCommand("UPDATE [RMAData].[dbo].[IMPORTING_ORDER_EDI] SET valid = 0, active = 0 WHERE record = " + reader["record"].ToString() + ";", connection1);
                
                update.ExecuteNonQuery();
               }
             }
             else
             {
                ///blah
             }
          }
          reader.Close();
       }
    }
