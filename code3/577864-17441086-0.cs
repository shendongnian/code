    public class TableStorageManager
    {
        private CloudTableClient TableClient;
        private CloudTable Table;
        #region Sigleton implementation
        public TableStorageManager(string tablename)
        {
            TableClient = StorageFactory.GetCloudStorageAccount().CreateCloudTableClient();
            Table = TableClient.GetTableReference(tablename);
            //var ctx = TableClient.GetTableServiceContext();
            
            Table.CreateIfNotExists();
        }
        #endregion
        public void InsertAnyEntity<T>(T entity)
        {
            var translatedEntity = Helper.ConvertToDictionaryEntity<T>(entity);
            InsertEntity<DictionaryEntity>(translatedEntity);
        }
        public void InsertEntity<T>(T entity) where T : ITableEntity
        {
            Table.Execute(TableOperation.InsertOrReplace(entity));
        }
        public IEnumerable<T> ExecuteQuery<T>(TableQuery<T> query) where T : class, ITableEntity, new()
        {
            return Table.ExecuteQuery(query);
        }
        public IEnumerable<T> GetEntities<T>(String partitionKey, Int32 noOfRecords ) where T : ITableEntity, new()
        {
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            var result = Table.ExecuteQuery(query).Take(noOfRecords).ToList();
            return result;
        }
        public T GetEntity<T>(String partitionKey, String rowKey) where T : class, ITableEntity, new()
        {
            var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            
            // Execute the retrieve operation.
            var retrievedResult = Table.Execute(retrieveOperation);
            return retrievedResult.Result as T;
        }
        public Boolean DeleleEntity<T>(String partitionKey, String rowKey) where T : class, ITableEntity, new()
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            // Execute the operation.
            var retrievedResult = Table.Execute(retrieveOperation);
            // Assign the result to a CustomerEntity.
            var deleteEntity = (T)retrievedResult.Result;
            // Create the Delete TableOperation.
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
                // Execute the operation.
                Table.Execute(deleteOperation);
            }
            return true;
        }
        public Boolean UpdateEntity<T>(String partitionKey, String rowKey) where T : class, ITableEntity, new()
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            // Execute the operation.
            TableResult retrievedResult = Table.Execute(retrieveOperation);
            // Assign the result to a CustomerEntity object.
            var updateEntity = (T)retrievedResult.Result;
            if (updateEntity != null)
            {
                // Create the InsertOrReplace TableOperation
                TableOperation updateOperation = TableOperation.Replace(updateEntity);
                // Execute the operation.
                Table.Execute(updateOperation);
            }
            return true;
        }
        public Boolean UpdateEntity<T>(T entity) where T : class, ITableEntity, new()
        {
            Boolean isUpdate = false;
            try
            {
                // Create the InsertOrReplace TableOperation
                TableOperation updateOperation = TableOperation.Replace(entity);
                // Execute the operation.
                Table.Execute(updateOperation);
                isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
            }
            return isUpdate;
        }
    }
