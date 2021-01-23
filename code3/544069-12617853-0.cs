    var connectionString = "...";
    using (SqlConnection connection = 
            new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
             var cmd = new SqlCommand("YourSP", connection);//Adjust your stored procedure name
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add(new SqlParameter("@SomeParameter", YourValue));//Adjust your value
                  
             adapter.SelectCommand = cmd;
             adapter.Fill(dataset);
            return dataset;
        }
