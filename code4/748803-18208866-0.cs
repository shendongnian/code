    void Main()
    {
    	var repo = new GenericRepository<ProductStyle>(new ProductStyle());
    	Console.WriteLine(repo.ToString());  //just output something to make sure it works...
    }
    
    // Define other methods and classes here
    public class GenericRepository<T> where T : BaseEntity {
    	private readonly T _inst;
    	
    	public GenericRepository(T inst){
    		_inst = inst;
    		_inst.DoSomething();
    	}
    }
    
    public class BaseEntity {
    	public Int32 Id {get;set;}
    	
    	public virtual void DoSomething() { Console.WriteLine("Hello"); }
    }
    
    public class ProductStyle : BaseEntity {
    }
