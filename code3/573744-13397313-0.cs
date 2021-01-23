    public static void UpdateShift(string sql)
        {
            SqlConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            SqlCommand sqlCommand = new SqlCommand(sql, dbConnection);
            sqlCommand.CommandType=CommandType.Text;
            sqlCommand.CommandText=sql;
            dbConnection.Open();
            sqlCommand.Connection = dbConnection;
            //sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteNonQuery();
            dbConnection.Close();
            ShiftInfoDBCache.Remove(SHIFTINFO_CACHE_KEY);
            
            
        }
