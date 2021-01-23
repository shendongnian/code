    public class EntityBucket
    {
      Dictionary<Type, List<IEntity>> entities = new Dictionary<Type, List<IEntity>>();
    
      public void Add<T>(T item) where T : IEntity
      {
        Type tType = typeof(T);
        if (!entities.ContainsKey(tType))
        {
          entities.Add(tType, new List<IEntity>());
        }
        entities[tType].Add(item);
      }
    
      public List<T> GetList<T>() where T : IEntity
      {
        Type tType = typeof(T);
        if (!entities.ContainsKey(tType))
        {
          return new List<T>();
        }
        return entities[tType].Cast<T>().ToList();
      }
    
      public List<IEntity> GetAll()
      {
        return entities.SelectMany(kvp => kvp.Value)
          .Distinct() //to remove items added multiple times, or to multiple lists
          .ToList();
      }
    
    }
