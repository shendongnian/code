    string sql = "SELECT TOP 1 remain FROM dbo.tablename WHERE cust=@cust ORDER BY id DESC";
    using(var con = new SqlConnection(connectionString))
    using(var cmd = new SqlCommand(sql, con))
    {
        cmd.Parameters.AddWithValue("@cust", textBox2.Text);
        con.Open();
        double h = (double)cmd.ExecuteScalar();
        textBox20.Text = h.ToString();
    }
