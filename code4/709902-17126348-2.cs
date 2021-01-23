    public class MyRespository
    {
        public bool IsIdUnique(int id)
        {
          Entity entity = _entitySet.FirstOrDefault( item => item.Id == id );
          return entity == null ? true : false;
        }
    }
    
    public class MyService
    {
      public void ServiceMethod(Entity entity)
      {
        if( _repository.IsIdUnqiue(entity.Id) )
        {
          // entity.Id is unique!
        }
        else
        {
          // entity.Id is not unique!
        }
      }
    }
