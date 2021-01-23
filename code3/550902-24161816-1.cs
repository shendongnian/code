    using (ShimsContext.Create())
    {                  
        ShimLinqExtensionMethods.AsQueryableOf1MongoCollectionOfM0(
            (MongoCollection<T> x) => Fake_DB_Collection.AsQueryable());
        // After this, the above "collection.AsQueryable()" will be mocked as 
        // an in-memory collection, which can be any subclass of IEnumerable<T>             
    } 
