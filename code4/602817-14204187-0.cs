    string sql = @"Data Source=.;Initial Catalog=test;Integrated Security=True";
    SqlConnection conn = new SqlConnection(sql);
    conn.Open();
    SqlDataAdapter adaptor = new SqlDataAdapter("<sql query>", conn);
    DataTable dt = new DataTable();
    adaptor.Fill(dt);
