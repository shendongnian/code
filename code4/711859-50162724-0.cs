    public class MongoDatabase<T> : IDatabase<T> where T : class, new()
        {
            private static string connectionString = "connectionString";
    
            private static IMongoClient server = new MongoClient(connectionString);
    
            private string collectionName;
    
            private IMongoDatabase db;
    
            protected IMongoCollection<T> Collection
            {
                get
                {
                    return db.GetCollection<T>(collectionName);
                }
                set
                {
                    Collection = value;
                }
            }
    
            public MongoDatabase(string collection)
            {
                collectionName = collection;
    
                db = server.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
            }
    
            public IMongoQueryable<T> Query
            {
                get
                {
                    return Collection.AsQueryable<T>();
                }
                set
                {
                    Query = value;
                }
            }
    
            public T GetOne(Expression<Func<T, bool>> expression)
            {
                return Collection.Find(expression).SingleOrDefault();
            }
    
            public T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
            {
                return Collection.FindOneAndUpdate(expression, update, option);
            }
    
            public void UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
            {
                Collection.UpdateOne(expression, update);
            }
    
            public void DeleteOne(Expression<Func<T, bool>> expression)
            {
                Collection.DeleteOne(expression);
            }
    
            public void InsertMany(IEnumerable<T> items)
            {
                Collection.InsertMany(items);
            }
    
            public void InsertOne(T item)
            {
                Collection.InsertOne(item);
            }
        }
