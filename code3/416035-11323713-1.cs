    string strTesaConnectionString = ConfigurationManager.ConnectionStrings["TESA_ConnectionString"].ConnectionString;
    string strBaseConnectionString = ConfigurationManager.ConnectionStrings["BASE_ConnectionString"].ConnectionString;
    if(1)
    {
      using (MySqlConnection DBConnection = new MySqlConnection(strTesaConnectionString))
       { ... }
    }
    if(2)
    {
      using (MySqlConnection DBConnection = new MySqlConnection(strBaseConnectionString ))
       { ... }
    }
