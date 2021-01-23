    try {
        using (var sqlConn = new SqlConnection(myConnectionString)) {
            using (SqlCommand cmd = sqlConn.CreateCommand()) {
                sqlConn.Open();
                AttachParameters(cmd, e);
                cmd.ExecuteNonQuery();
            }
        }
    } catch (Exception ex) {
        Logger.Instance.Fatal(ex);
    }
