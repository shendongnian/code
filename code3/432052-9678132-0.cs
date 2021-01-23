       public class GenericRepository<TEntity> where TEntity : class 
        { 
            internal SchoolDBContext context; 
            internal DbSet<TEntity> dbSet; 
     
            public GenericRepository(SchoolDBContext context) 
            { 
                this.context = context; 
                this.dbSet = context.Set<TEntity>(); 
            } 
            
    	    public virtual IEnumerable<TEntity> Get( 
    	      Expression<Func<TEntity, bool>> filter = null, 
    	      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
    	      string includeProperties = "") 
    	    {
    		...
    	    }
    	
    	    public virtual TEntity GetByID(object id) 
    	    { 
    	       return dbSet.Find(id); 
    	    }
            
    	    public virtual void Insert(TEntity entity) 
    	    { 
    	      dbSet.Add(entity); 
    	    } 
    	
    	  ...
         }
     
