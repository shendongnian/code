    string connString =
                "server=(local)\\SQLEXPRESS;database=MyDatabase;Integrated Security=SSPI";
    string sql = @"SELECT TOP 1 * FROM AnyTable";
    using (SqlConnection conn = new SqlConnection(connString)) {
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        using (DataSet ds = new DataSet()) {
            da.Fill(ds, "AnyTable");
            DataTable dt = ds.Tables["AnyTable"];
            foreach (DataColumn col in dt.Columns) {
                if (col.Unique) {
                    Console.WriteLine("Column {0} is unique.", col.ColumnName);
                }
            }
        }
    }
