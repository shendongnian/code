     public class CloudTableRepository<T> where T : ITableEntity,new ()
    {
        private readonly string _tableName;
        private CloudTable _table;
        public CloudTableRepository(string tableName)
        {
            _tableName = tableName;
            InitializeTable();
        }
        #region Public Methods
        public virtual async Task<List<T>> GetPartitionAsync(string partitionKey, int takeCount = 1000)
        {
            var result = new List<T>();
            var query =
                new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal,
                    partitionKey));
            query.TakeCount = takeCount;
            TableContinuationToken tableContinuationToken = null;
            do
            {
                var queryResponse = await _table.ExecuteQuerySegmentedAsync(query, tableContinuationToken);
                tableContinuationToken = queryResponse.ContinuationToken;
                result.AddRange(queryResponse.Results);
            } while (tableContinuationToken != null);
            return result;
        }
        public virtual async Task<TableResult> GetSingleAsync(string partitionKey, string rowKey)
        {
           return  await GetSingle(partitionKey, rowKey);
        }
        public virtual async Task<T> UpdateAsync(T tableEntityData)
        {
            var updateCallistConfig = await GetSingleAsync(tableEntityData.PartitionKey, tableEntityData.RowKey);
            if (updateCallistConfig != null)
            {
                var updateOperation = TableOperation.InsertOrMerge(tableEntityData);
                var tableResult = await _table.ExecuteAsync(updateOperation);
                return (T) tableResult.Result;
            }
            return default(T);
        }
        public virtual async Task<T> AddAsync(T tableEntityData)
        {
            var retrieveOperation = TableOperation.Insert(tableEntityData);
            var tableResult = await _table.ExecuteAsync(retrieveOperation);
            return (T) tableResult.Result;
        }
        #endregion
        #region Private Methods
        private async void InitializeTable()
        {
            var storageAccount =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("TableStorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(_tableName);
            await _table.CreateIfNotExistsAsync();
        }
        private async Task<TableResult> GetSingle(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var tableResult = await _table.ExecuteAsync(retrieveOperation);
            return tableResult; //(T) tableResult.Result;
        }
        #endregion
    }
