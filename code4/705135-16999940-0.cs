    public Task<IEnumerable<Exception>> ExecuteOnServersAsync(
        IList<IEnumerable<Connection>> dbConnByServer,
        string sql, object parameters)
    {
        var tasks = new List<Task>();
        var exceptions = new ConcurrentQueue<Exception>();
        Action<Task> handleException = t =>
        {
            if (t.IsFaulted)
                exceptions.Enqueue(t.Exception);
        };
        foreach (var dbConns in dbConnByServer)
        {
            Task task = null;
            foreach (var dbConn in dbConns)
            {
                var sqlUtil = m_sqlUtilProvider.Get(dbConn);
                if (task == null)
                {
                    task = sqlUtil.ExecuteSqlAsync(sql, parameters);
                }
                else
                {
                    task = task.ContinueWith(
                        t =>
                        {
                            handleException(t);
                            return sqlUtil.ExecuteSqlAsync(sql, parameters);
                        }).Unwrap();
                }
            }
            if (task != null)
            {
                task = task.ContinueWith(handleException);
                tasks.Add(task);
            }
        }
        return Task.Factory.ContinueWhenAll(
            tasks.ToArray(), _ => exceptions.AsEnumerable());
    }
