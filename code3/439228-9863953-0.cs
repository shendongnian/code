    void Main()
    {
    	var builder = new Builder();
    	var unbuilt = new List<ModelForBuild>();
    	builder.Build<ModelForBuild>( m => m.Id == 0, unbuilt);
    }
    
    public class Builder
    {
    	public IEnumerable<ModelForBuild> Values{ get; private set; }
        
    	public void Build<T>( Func<T, bool> screen, 
                              IEnumerable<T> items ) where T : class
    	{
            Values = items.Where(screen).Select(
                i => new ModelForBuild{ Id = 1 }).ToList();
    	}
    }
    
    public class ModelForBuild
    {
        public int Id {get;set;}
    }
