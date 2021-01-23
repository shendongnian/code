    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        String orderNo=txt_orderno.Text;
        SqlCommand cmd= new SqlCommand(gridalldata, connection);
        cmd.CommandType=CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@order_no", orderNo);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
          
        }
    }
    
