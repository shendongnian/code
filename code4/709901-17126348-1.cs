    public class MyRepository
    {
      public MyEntity GetById(int id)
      {
        return _entitySet.FirstOrDefault( item => item.Id == id );
      }
    }
    
    public class MyService
    {
      public void ServiceMethod(Entity entity)
      {
        if( _repository.GetById( entity.Id ) == null)
        {
          // entity.Id is unique!
        }
        else
        {
          // entity.Id is not unique!
        }
      }
    }
