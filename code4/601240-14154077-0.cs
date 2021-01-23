    const string sql = @"SELECT 
                            COUNT(CUSTOMER_NO) 
                         FROM 
                            WEBSITE_CUSTOMERS 
                         WHERE 
                            UPPER(CUSTOMER_NO) = @CUSTOMER_NO;";
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using (SqlCommand cmdCheck = new SqlCommand(sql, connection))
        {
            cmdCheck.Parameters.AddWithValue("@CUSTOMER_NO", strCustomer.Trim().ToUpper());
            connection.Open();
            int nExists = (int)cmdCheck.ExecuteScalar();
            return nExists > 0;
        }
    }
