        SqlConnection sc = new SqlConnection();
        sc.ConnectionString = MyConnectionString
        SqlCommand scm = new SqlCommand(INSERT COMMAND);
        sc.Open();
        scm.ExecuteNonQuery();
        sc.Close();
