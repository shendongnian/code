    public class TestBase : IUseFixture<OneTimeFixture<ApplicationFixture>>
    {
    	protected ApplicationFixture Application;
    
    	public void SetFixture(OneTimeFixture<ApplicationFixture> data)
    	{
    		this.Application = data.Fixture;
    	}
    }
    
    public class ApplicationFixture : IDisposable
    {
    	public ApplicationFixture()
    	{
    		// This code run only one time
    	}
    
    	public void Dispose()
    	{
    		// Here is run only one time too
    	}
    }
    
    public class OneTimeFixture<TFixture> where TFixture : new()
    {
    	// This value does not share between each generic type
    	private static readonly TFixture sharedFixture;
    
    	static OneTimeFixture()
    	{
    		// Constructor will call one time for each generic type
    		sharedFixture = new TFixture();
    		var disposable = sharedFixture as IDisposable;
    		if (disposable != null)
    		{
    			AppDomain.CurrentDomain.DomainUnload += (sender, args) => disposable.Dispose();
    		}
    	}
    
    	public OneTimeFixture()
    	{
    		this.Fixture = sharedFixture;
    	}
    
    	public TFixture Fixture { get; private set; }
    }
