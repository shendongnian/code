    QueryExecutor executor;
    public void Example()
    {
        var query = new ActiveUsersQuery { InData1 = 1, InData2 = "text" };
        executor.Execute(query);
        var data = query.OutData1; // use output here;
    }
