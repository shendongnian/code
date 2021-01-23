        public int RemoveDinners(List<string> dinnerItems)
        {
            using (var sqlConn = new SqlConnection(_sqlConnectionString))
            {
                const string sqlQuery = "delete from DinnerTemplates where Dinner in ({0})";
                using (var command = new SqlCommand())
                {
                    var paramNames = new string[dinnerItems.Count];
                    int i = 0;
                    foreach (string item in dinnerItems)
                    {
                        string paramName = "@Dinner" + i;
                        command.Parameters.AddWithValue(paramName, item);
                        paramNames[i] = paramName;
                        i += 1;
                    }
                    command.CommandText = String.Format(sqlQuery, String.Join(",", paramNames));
                    command.Connection = sqlConn;
                    command.CommandType = CommandType.Text;
                    sqlConn.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
