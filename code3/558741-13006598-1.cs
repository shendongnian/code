    string query = "INSERT INTO mytable (p_num, p_date) SELECT @num,@dt";
    using (SqlConnection conn = new SqlConnection("....."))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("num", 1);
            cmd.Parameters.AddWithValue("dt", DateTime.Today);
            cmd.ExecuteNonQuery();
        }
        conn.Close();
    }
