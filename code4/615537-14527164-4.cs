    public static Task<T> ExecuteAsync<T>(this OurDBConn dataSource, Func<OurDBConn, T> function)
    {
        string connectionString = dataSource.ConnectionString;
        // Start the SQL and pass back to the caller until finished
        return Task.Run(
            () =>
            {
                // Copy the SQL connection so that we don't get two commands running at the same time on the same open connection
                using (var ds = new OurDBConn(connectionString))
                {
                    return function(ds);
                }
            });
    }
    public static Task<ResultClass> GetTotalAsync( ... )
    {
        return this.DBConnection.ExecuteAsync<ResultClass>(
            ds => ds.Execute("select slow running data into result"));
    }
