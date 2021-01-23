    public class SQLRepository<T> : IRepository<T> where T : class
    {
    	private DataContext db;
    	public SQLRepository()
    	{
    	    this.db = new TestDataContext();
    	}
    	public void Add(T entity)
    	{
    	    db.GetTable(Of T)().InsertOnSubmit(entity)
    	}
    	public void Delete(T entity)
    	{
    	    db.GetTable(Of T)().DeleteOnSubmit(entity)
    	}
    	public System.Collections.Generic.List<T> FetchAll()
    	{
    	    return Query.ToList();
    	}
    	public System.Linq.IQueryable<T> Query {
    	    get { return db.GetTable<T>(); }
    	}
    	public void Save()
    	{
    	    db.SubmitChanges()
    	}
    }
