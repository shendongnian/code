    public interface IRepository<T> 
    {
    	void Add(T entity);
    }
    
    public class Repository<T> : IRepository<T> 
    {
        // mocking Add so it works without a DB
    	public virtual void Add(T entity) 
    	{
    		Console.WriteLine("{0} added", entity.ToString());
    	}
    }
    
    public class Tenant 
    {
    	public string Name{get; private set;}
    	public Tenant(string Name)
    	{
    		this.Name=Name;
    	}
    	
        public override string ToString() {return this.Name;}
    
    }
    
    public class TenantRepository : Repository<Tenant>
    {
        // Add is virtual, so it can be overridden by TenantRepository
    	public override void Add(Tenant entity)
    	{
    		// this represents your uniqueness check
    		if(entity.Name=="Paolo") throw new Exception();
    		
    		base.Add(entity); // calling Add on the base Repository
    	}
    	
        //you can now avoid having Create or making it just call Add
    	public Tenant Create(Tenant entity) 
    	{
    		this.Add(entity);
    		return entity;
    	}
    }
