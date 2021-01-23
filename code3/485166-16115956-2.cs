    #region connection
    CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
    CloudTableClient client = account.CreateCloudTableClient();
    CloudTable table = client.GetTableReference("mytable");
    table.CreateIfNotExists();
    #endregion
    const string decimalPrefix = "D_";
    const string partitionKey = "BlaBlaBla";
    string rowKey = DateTime.Now.ToString("yyyyMMddHHmmss");
    #region Insert
    var entity = new MyEntity
        {
            PartitionKey = partitionKey,
            RowKey = rowKey,
            MyProperty = "Test",
            MyDecimalProperty1 = (decimal) 1.2,
            MyDecimalProperty2 = (decimal) 3.45
        };
    TableOperation insertOperation = TableOperation.Insert(entity);
    table.Execute(insertOperation);
    #endregion
    #region Retrieve
    EntityResolver<MyEntity> myEntityResolver = (pk, rk, ts, props, etag) =>
        {
            var resolvedEntity = new MyEntity {PartitionKey = pk, RowKey = rk, Timestamp = ts, ETag = etag};
            foreach (var item in props.Where(p => p.Key.StartsWith(decimalPrefix)))
            {
                string realPropertyName = item.Key.Substring(decimalPrefix.Length);
                System.Reflection.PropertyInfo propertyInfo = resolvedEntity.GetType().GetProperty(realPropertyName);
                propertyInfo.SetValue(resolvedEntity, Convert.ChangeType(item.Value.StringValue, propertyInfo.PropertyType), null);
            }
            resolvedEntity.ReadEntity(props, null);
            return resolvedEntity;
        };
    TableOperation retrieveOperation = TableOperation.Retrieve(partitionKey, rowKey, myEntityResolver);
    TableResult retrievedResult = table.Execute(retrieveOperation);
    var myRetrievedEntity = retrievedResult.Result as MyEntity;
    // myRetrievedEntity.Dump(); 
    #endregion
