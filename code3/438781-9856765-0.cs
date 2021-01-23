    string concert = "webpage title or string from webpage";
    using(SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connString"].ConnectionString))
    {
       string sqlSelect = @"select price 
                            from tickets 
                            where concert_name = @searchString";
       SqlCommand cmd = new SqlCommand(strSelect, conn);
       cmd.Parameters.AddWithValue("@searchString", concert);
       conn.Open();
       priceLabel.Text = cmd.ExecuteScalar().ToString();
    }
