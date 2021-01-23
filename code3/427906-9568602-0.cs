    SqlConnection DbConn = new SqlConnection(YourConnectionString);
    SqlCommand ExecJob = new SqlCommand();
    ExecJob.CommandType = CommandType.StoredProcedure;
    ExecJob.CommandText = "msdb.dbo.sp_start_job";
    ExecJob.Parameters.AddWithValue("@job_name", "YourJobName")
    
    using (DbConn)
    {
        DbConn.Open();
        using (ExecJob)
        {
            ExecJob.ExecuteNonQuery();
        }
    }
