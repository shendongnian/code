    using (MySqlCommand cmd = new MySqlCommand(query, con))
    {
        cmd.Parameters.AddWithValue("@ID", txtboxID.Text);
        object result = cmd.ExecuteScalar();
        if(result != null)
        {
            int quantity = Convert.ToInt32(result);
            // Now you need to find the row that contains the ID passed 
            ......
            
        }
    }
