    string sql = string.Format("SELECT IDENT_CURRENT('{0}');", yourTableName);
    using (SqlConnection conn = new SqlConnection(connString))
    using (SqlCommand cmd = new SqlCommand(sql, conn))
    {
        conn.Open();
        _ID = (Int32)cmd.ExecuteScalar();
        conn.Close();
    }
