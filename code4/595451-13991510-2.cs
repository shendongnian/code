    public abstract class RepositoryBase<T> : IRepository<T>, IRepository
    {
    	public abstract IList<T> GetAll();
    	IList<object> IRepository.GetAll()
    	{
    		return this.GetAll().Cast<object>().ToList();
    	}
    }
