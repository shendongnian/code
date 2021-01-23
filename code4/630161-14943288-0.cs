    string sqlcheck = "SELECT * FROM " + table + " WHERE CUST_NO = @customerNumber";
    
    using (SqlConnection connect = new SqlConnection(DBConnection String))
    {
       using (SqlCommand command = new SqlCommand(sqlcheck, connect))
       {
         command.Parameters.AddWithValue("@customerNumber", customerNumber);
         connect.Open();
         response = (string)(command.ExecuteScalar());
       }
    }
