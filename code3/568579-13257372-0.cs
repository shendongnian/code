    public interface IMongoDBRepository
    {
       Collection<T> GetCollection<T>(string name) where T BsonDocument;
    }
    
    public class MongoDbRepository : IMongoDBRepository
    {
       public Collection<T> GetCollection<T>(string name) 
         where T : BsonDocument
       {
          return MongoDatabase.GetCollection<BsonDocument>(name);
       }
    }
