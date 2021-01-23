    public static IEnumerable<T> Get(CloudStorageAccount storageAccount, string tableName, string filter)
        {
            string tableEndpoint = storageAccount.TableEndpoint.AbsoluteUri;
            var tableServiceContext = new TableServiceContext(tableEndpoint, storageAccount.Credentials);
            string query = string.Format("{0}{1}()?filter={2}", tableEndpoint, tableName, filter);
            var queryResponse = tableServiceContext.Execute<T>(new Uri(query)) as QueryOperationResponse<T>;
            return queryResponse.ToList();
        }
