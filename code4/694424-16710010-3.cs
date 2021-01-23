    // The query returns also the Variant column from the database
    // The column is needed to identify the corresponding row to update on the datagridview
    // Also I am supposing that the variant column is from the same table (JOIN required otherwise)
    string query = @"SELECT variant, quantity 
                    FROM tblOrder_Products
                    WHERE order_ID=@ID";
    con.Open();
    using (MySqlCommand cmd = new MySqlCommand(query, con))
    {
        cmd.Parameters.AddWithValue("@ID", txtboxID.Text);
        // Cannot use a ExecuteScalar, we need a SqlDataReader to loop over the results
        SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int quantity = reader.GetInt32(1);
            // Now I am supposing the the Variant column is of string type, change the Get 
            // accordingly if it is not 
            string v = reader.GetString(0);
            // Use the value retrieved from the database to identify the row to update
            DataGridViewRow row = grid.Rows
                                 .Cast<DataGridViewRow>()
                                 .Where(r => r.Cells["variant"].Value.ToString().Equals(v))
                                 .First();
            row.Cells["Quantity"].Value = quantity;
        }
    }
