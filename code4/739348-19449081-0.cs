    ServicePoint tableServicePoint = ServicePointManager
        .FindServicePoint(_StorageAccount.TableEndpoint);
            
    //This is a notorious issue that has affected many developers. By default, the value 
    //for the number of .NET HTTP connections is 2.
    //This implies that only 2 concurrent connections can be maintained. This manifests itself
    //as "underlying connection was closed..." when the number of concurrent requests is
    //greater than 2.
    tableServicePoint.ConnectionLimit = 1000;
