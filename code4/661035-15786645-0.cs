    using (SqlConnection conn = new SqlConnection(connStr)) {
    using(SqlCommand comm = new SqlCommand()) {
    comm.Connection = conn;
    comm.CommandText = sql;
...
    try {
    conn.Open();
    comm.ExecuteNonQuery();
    }
    catch(SqlException e) {
    // in case something is wrong
    }
    }
    }
