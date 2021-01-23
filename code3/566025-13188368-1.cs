    string connString = AppConfigurationManager.GetAppSetting("ConnectionString");
    using (var conn = new SqlConnection(connString))
    {
        conn.Open();
        using (SqlCommand sqlCommand = new SqlCommand("SELECT pin, " +
    "firstName, balanceAmount FROM accountInformation " +
    "WHERE accountNumber = '" + userAccountNumber + "'", conn))
        {
            sqlCommand.CommandType = CommandType.Text;
            SqlDataReader dr = null;
            try
            {
                dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    pin = dr.getString("pin");
                    firstName = dr.getString("firstName");
                    balance = dr.getDouble("balanceAmount");
                }
            }
            catch (SqlException ex)
            {
              
              
        }
        catch (Exception ex)
        {
                        
        }
        finally
        {
            //clean up resources that access Data
            if (dr != null)
            {
                dr.Close();
            }
        }
    }
