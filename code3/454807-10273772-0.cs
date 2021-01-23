    private static int SqlExec(string ConnectionString, string StoredProcName, Action<SqlCommand> AddParameters, Action<SqlCommand> PostExec)
            {
                int ret;
                using (var cn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(StoredProcName, cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    if (AddParameters != null)
                    {
                        AddParameters(cmd);
                    }
    
                    ret = cmd.ExecuteNonQuery();
    
                    if (PostExec != null)
                    {
                        PostExec(cmd);
                    }
                }
                return ret;
            }
