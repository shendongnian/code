	using System.Data.Entity;
	public class DataAccessBase<T>
	{
		// For example redirect this to a DbContext.Set<T>().
		public IQueryable<T> DataSet { get; private set; }
	
		public IQueryable<T> Include(Func<IQueryable<T>, IQueryable<T>> include = null)
		{
			if (include == null)
			{
				// If omitted, apply the default Include() method 
				// (will call overridden Include() when it exists) 
				include = Include;
			}
			
			return include(DataSet);
		}
		
		public virtual IQueryable<T> Include(IQueryable<T> entities)
		{
			// provide optional entities.Include(f => f.Foo) that must be included for all entities
			return entities;
		}
	}
