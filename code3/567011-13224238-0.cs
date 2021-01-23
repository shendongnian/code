    public void OutputSQLToTextFile(SqlCommand sqlCommand)
    {
            string query = sqlCommand.CommandText;
            foreach (SqlParameter p in sqlCommand.Parameters)
            {
                query = query.Replace(p.ParameterName, p.Value.ToString());
            }
            OutputToTextFile(query);
        }
