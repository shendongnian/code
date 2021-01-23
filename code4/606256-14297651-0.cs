    public List<IJob> getJobs(Func<FullTimeJob, Student, FullTimeJob> lambda)
    {
      using (SqlConnection connection = new SqlConnection(getConnectionString())) {
        connection.Open();
        return connection.Query<FullTimeJob, Student, FullTimeJob>(sql, 
            lambda,
            splitOn: "user_id",
            param: parameters).ToList<IJob>();   
      }  
    }
