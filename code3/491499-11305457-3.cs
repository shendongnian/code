    class CrudController<TEntity> where T : class{
        CrudRepository<TEntity> Repository;
    
        [HttpPost]
        ActionResult Add(TEntity entity){
          Repository.Add(entity);
        }
    
        // Similer for other actions
    }
