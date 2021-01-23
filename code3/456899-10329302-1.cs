    #if INCLUDE_FOR_TEST_ONLY
    public class Facts
    {
    	[Fact]
    	public void Fact()
    	{
    		Fixture fixture = new Fixture();
    		fixture.Register( ( string name ) => BarsForTestOnly.Create( name ) );
    		var anonymousBar = fixture.CreateAnonymous<Bar>();
    	}
    }
    #endif
