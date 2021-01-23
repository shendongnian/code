    public void AddCustomer(string companyName, string telephone, DateTime firstOrderDate)
    {
       // get your connection string
       string connectionString = ConfigurationManager.ConnectionStrings["YourConnString"].ConnectionString;
    
       // define your query - using parameters!
       string insertStmt = "INSERT INTO dbo.Customer(CompanyName, Telephone, DateOfFirstOrder) VALUES (@Company, @Phone, @OrderDate)";
    
       // establish SQL connection and command
       using(SqlConnection conn = new SqlConnection(connectionString))
       using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
       {
          // define parameters and set values
          cmd.Parameters.Add("@Company", SqlDbType.NVarChar, 50).Value = companyName;
          cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 10).Value = telephone;
          cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = firstOrderDate;
    
          // open connection, insert data, close connection
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
       }
    }
