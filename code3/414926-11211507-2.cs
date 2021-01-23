    [PrioritizedFixture]
    public class MyTests
    {
    	[Fact, TestPriority(1)]
    	public void FirstTest()
    	{
    		// Test code here is always run first
    	}
    	[Fact, TestPriority(2)]
    	public void SeccondTest()
    	{
    		// Test code here is run second
    	}
    }
