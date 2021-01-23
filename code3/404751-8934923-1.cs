    using (SqlConnection conn = new SqlConnection(connStr))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();    
        conn.Open();
        DataTable dt = new DataTable();
        using (SqlCommand cmd = new SqlCommand("CustOrdersOrders", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CustomerID", "AROUT");           
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
        }
    
        GridView1.DataSource = dt;                
        GridView1.DataBind();
    }
