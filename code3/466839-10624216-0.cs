    public MongoCollection<T> GetCollection<T>(string name = null)
            {
                string collectionName = name;
                if (collectionName == null)
                    collectionName = typeof(T).Name;
                if (Database.CollectionExists(collectionName) == false)
                    Database.CreateCollection(collectionName);
                return Database.GetCollection<T>(collectionName);
            }
