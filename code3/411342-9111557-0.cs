    public abstract class BaseMongoService<T> where T : BaseDocument
    {
       protected abstract MongoCollection Items { get; }
    
       public virtual SafeModeResult Save(T document)
       {
          document.LastUpdatedOn = DateTime.Now;
    
          return Items.Save(document);
       }
       public virtual void Update(IMongoQuery query, IMongoUpdate update)
       {
          update = update.Set("LastUpdatedOn", DateTime.Now);
          Items.Update(query, update);
       }
    }
