        public SqlDataReader executeReader(string sql, SqlParameter[] parameters=null)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = GetSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            if (parameters != null)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
