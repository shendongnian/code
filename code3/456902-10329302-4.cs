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
	[Fact]
	public void FactSyntax2() // Just a variant of Fact above
	{
		Fixture fixture = new Fixture();
		fixture.Register<string, Bar>( BarsForTestOnly.Create );
		var anonymousBar = fixture.CreateAnonymous<Bar>();
	}
	[Fact]
	public void UsingFromFactory()
	{
		Fixture fixture = new Fixture();
		fixture.Customize<Bar>(  x=> x.FromFactory<string>( BarsForTestOnly.Create ) );
		var anonymousBar = fixture.CreateAnonymous<Bar>();
	}
    #endif
