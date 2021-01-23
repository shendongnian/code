                CloudTable table = tableClient.GetTableReference(<TableName>);
                table.CreateIfNotExists();
                TableQuery<YourAzureTableEntity> query =
                   new TableQuery<YourAzureTableEntity>()
                      .Where(whereClause));
                var list = table.ExecuteQuery(query).ToList();
