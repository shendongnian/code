    public static T Do<T>(string RowKey, string partitionKey, string tableName)
    {
        var theTable = Connect.Initialize(tableName);
        var retrieveOperation = TableOperation.Retrieve<T>(
                                          Base64.EncodeTo64(partitionKey),
                                          Base64.EncodeTo64(RowKey),
										  T.Columns);
    
        var retrievedResult = theTable.Execute(retrieveOperation);
    
        if (retrievedResult.Result != null) {
            return retrievedResult.Result;
        }
         throw new ArgumentException(
                     String.Format("{0} not found in the Table", RowKey));
    }
