    using (SqlConnection conn = new SqlConnection("ConnectionString"))
    using (SqlCommand cmd = new SqlCommand())
    {
        cmd.CommandText = "INSERT into yourTable(ID, Col1, Col2) VALUES (@ID, @Col1, @Col2);";
        cmd.Connection = conn;
        conn.Open();
        cmd.Parameters.AddWithValue("@ID", yourID);
        cmd.Parameters.AddWithValue("@Col1", string.IsNullOrWhiteSpace(textBox1.Text) ? 
                                              null : textBox1.Text);
        cmd.Parameters.AddWithValue("@Col2", string.IsNullOrWhiteSpace(textBox2.Text) ?
                                              null : textBox2.Text);
        cmd.ExecuteNonQuery();
    }
