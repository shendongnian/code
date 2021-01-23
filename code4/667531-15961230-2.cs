            try
            {
                xavierConnection.Open();
    
                SqlCommand RiskRevalCommand = new SqlCommand("select * from CreditAdmin.dbo.CreditData_Test", xavierConnection/*don't forget this*/);
    
    
                SqlDataReader reader = RiskRevalCommand.ExecuteReader();
    
                while (reader.Read())
                {
                   //no need to try-catch here
                   double.TryParse(reader["Available Balance"].ToString(), out _availability);
                        ...
                }
             }
             catch (Exception e)
             {
                  MessageBox.Show(e.Message);
             }
             finally
             {
                  xavierConnection.Close();
             }
