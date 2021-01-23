    DbCommand comm2 = conn.CreateCommand();
    comm2.CommandText = "Select IDENT_CURRENT('userinfo')";
    comm2.Connection = conn;
    String id = comm2.ExecuteScalar().ToString();
    conn.Close();
