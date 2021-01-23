        // Get from config
        string connectionString = "";
        using (var conn = new SqlConnection(connectionString))
        {
            string sql = "insert Table_2 (Test) values( CONVERT(varbinary(30), @nvarcharParam) )";
            using (var cmd = new SqlCommand(sql, conn))
            {
                var param = cmd.Parameters.AddWithValue("nvarcharParam", "This is a test");
                param.DbType = DbType.String;
                cmd.ExecuteNonQuery();
            }
        }
