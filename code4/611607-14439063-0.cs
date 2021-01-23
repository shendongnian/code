    public static class MongoExtensions
    {
        static readonly ProxyGenerator pg = new ProxyGenerator();
        public static MongoCollection GetRetryCollection(this MongoDatabase db, string collectionName, int retryCount = 5, int pauseBetweenRetries = 2000)
        {
            var coll = db.GetCollection(collectionName);
            return (MongoCollection)pg.CreateClassProxyWithTarget(typeof(MongoCollection), coll, new object[] { db, collectionName, coll.Settings }, new RetryingInterceptor { RetryCount = retryCount, PauseBetweenCalls = pauseBetweenRetries });
        }
    }
