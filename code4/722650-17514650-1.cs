        public static int GetNextIdOfTable(string aTableName)
        {
            int lNextID = 0;
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GET_NEXT_AUTO_ID_OF_TABLE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TABLE_NAME", aTableName) { Direction = System.Data.ParameterDirection.Input, SqlDbType = System.Data.SqlDbType.NVarChar });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@NEXT_ID", Direction = System.Data.ParameterDirection.Output, SqlDbType = SqlDbType.Int });
                conn.Open();
                cmd.ExecuteReader();
                if (cmd.Parameters["@NEXT_ID"] != null && cmd.Parameters["@NEXT_ID"].Value != DBNull.Value)
                    return int.Parse(cmd.Parameters["@NEXT_ID"].Value.ToString());
            }
            return lNextID;
        }
