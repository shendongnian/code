    public class Singleton
    {
    	private static readonly Task<Singleton> _getInstanceTask = CreateSingleton();
    
    	public static Task<Singleton> Instance
    	{
    		get { return _getInstanceTask; }
    	}
    
    	private Singleton(SomeData someData)
    	{
    		SomeData = someData;
    	}
    
    	public SomeData SomeData { get; private set; }
    
    	private static async Task<Singleton> CreateSingleton()
    	{
    		SomeData someData = await LoadData();
    		return new Singleton(someData);
    	}
    }
