    .....
    // Use parameters **ALWAYS** -- **NEVER** cancatenate/substitute strings 
    string query = "select stationipaddress from station where stationname = @name";
    using (SqlCommand cmd = new SqlCommand(query, cs))
    {
        // Add the parameter and set its value -- 
        cmd.Parameters.AddWithValue("@name", textBox1.Text);
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                label3.Text = dr.GetSqlValue(0).ToString();
                results = dr.GetValue(0).ToString();
            }
        }
    }
    .....
