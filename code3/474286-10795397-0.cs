    public void IterateItems(Action<int, TEntity> handler)
    {
        String query = String.Format("SELECT {0} FROM {1}",AllFieldsSelection,TableName);
        var data = SqlExecutionData.Create().WithConn(ConnectionString).WithQuery(query);
   
        var index = 0;   
        foreach (IDataRecord record in SqlServerUtils.GetRecords(data))
        {
            handler(CreateOneFromRecord(index, record));
            index++;
        }
    }
