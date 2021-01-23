    SqlConnection conn = new SqlConnection();
    conn.ConnectionString(/* your connection string goes here */);
    conn.Open();
    SqlCommand cmd = new SqlCommand("insert into table values (1, 2, 3)", conn);
    cmd.ExecuteNonQuery();
    conn.Close();
