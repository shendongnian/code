    public class EntityBucket
    {
      public LinkedList<IEntity> Entities;
    
      public IEnumerable<T> GetEntities<T>() where T : IEntity
      {
        return Entities.OfType<T>();
      }
    
    }
    
    
    List<IUndead> myBrainFinders = bucket.GetEntities<IUndead>().ToList();
