    public class TestBase : IUseFixture<ApplicationFixture>
    {
    	protected ApplicationFixture Application;
    
    	public void SetFixture(ApplicationFixture data)
    	{
    		this.Application = data;
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
