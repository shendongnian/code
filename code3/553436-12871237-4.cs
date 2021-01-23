        SqlConnection sc = new SqlConnection();
        sc.ConnectionString = MyConnectionString
        SqlCommand scm = new SqlCommand(INSERT COMMAND);
        scm.Connection = sc;           // missing this.
        sc.Open();
        scm.ExecuteNonQuery();
        sc.Close();
