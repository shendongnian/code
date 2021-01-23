    using (SqlCommand cmd = new SqlCommand(query, connection);
    {
        // Assign parameters. I assume that you have DateTimePickers instead
        // of text boxes.
        cmd.Parameters.AddWithValue("@startDate", datePicker1.Date);           
        cmd.Parameters.AddWithValue("@endDate", datePicker2.Date);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            // Read all data into string builder (field name must be changed)
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
              sb.Append(reader["FieldName"].ToString());
            
            // Assign this to label
            label1.Text = sb.ToString();
        }
    }
