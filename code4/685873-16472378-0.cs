    oCn = new SqlConnection(ConfigurationSettings.AppSettings["GBRegistrationConnStr"].ToString());
    oCn.Open();
    oCmd = new SqlCommand();        
    
    oCmd.CommandText = sSQL;
    oCmd.Connection = oCn;
    oCmd.CommandType = CommandType.Text;
    ocmd.Parameters.AddWithValue("straccountid", strAccountID.Substring(0, 10)); //<-- You forgot to add in the parameter
    oDR = oCmd.ExecuteReader(CommandBehavior.CloseConnection);
