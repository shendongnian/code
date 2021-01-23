    int ThreadID = 0
    int.TryParse(Request.QueryString["id"], out ThreadID);
    if(ThreadID > 0)
    {
        string TopicName = string.Empty;
        string Sql = "SELECT Topic FROM <tablename> WHERE ThreadID = @ThreadID;";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(Sql, conn);
            cmd.Parameters.Add("@ThreadID", ThreadID);
            try
            {
                conn.Open();
                TopicName = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
