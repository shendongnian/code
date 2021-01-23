      public abstract class  BaseController<T> : ControllerBase  
                    where T : BaseObj, new()
      {
    
         public IQueryable<T> FilterEntities(IQueryable<T> entities)
         {
                return FilterEntities<T>(entities);
         }
    
         public IQueryable<TElement> FilterEntities<TElement>(IQueryable<TElement> entities) 
                    where TElement : BaseObj, new()
      }
