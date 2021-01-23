    string OutputToLabel = string.Empty;
    if(!string.IsNullOrEmpty(Request.QueryString["id"]))
    {
        int ThreadID = 0;
        int.TryParse(Request.QueryString["id"], out ThreadID);
        if(ThreadID > 0)
        {
            string Sql = "SELECT Topic FROM <tablename> WHERE ThreadID = @ThreadID;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(Sql, conn);
                cmd.Parameters.Add("@ThreadID", ThreadID);
                try
                {
                    conn.Open();
                    OutputToLabel = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
