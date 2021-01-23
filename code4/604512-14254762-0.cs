    // System.Data.Linq.Table<TEntity>
    public void InsertAllOnSubmit<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : TEntity
    {
    	if (entities == null)
    	{
    		throw Error.ArgumentNull("entities");
    	}
    	this.CheckReadOnly();
    	this.context.CheckNotInSubmitChanges();
    	this.context.VerifyTrackingEnabled();
    	List<TSubEntity> list = entities.ToList<TSubEntity>();
    	using (List<TSubEntity>.Enumerator enumerator = list.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    			TEntity entity = (TEntity)enumerator.Current;
    			this.InsertOnSubmit(entity);
    		}
    	}
    }
