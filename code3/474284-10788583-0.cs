    public IEnumerable<TEntity> GetAll()
            {
                String query = String.Format("SELECT {0} FROM {1}",AllFieldsSelection,TableName);
                var data = SqlExecutionData.Create().WithConn(ConnectionString).WithQuery(query);
                foreach (IDataRecord record in SqlServerUtils.GetRecords(data))
                {
                    yield return CreateOneFromRecord(record);
                }
            }
