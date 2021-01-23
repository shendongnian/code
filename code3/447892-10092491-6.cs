    public class AnOpenGenericsBinderDemo
    {
    	[Fact]
    	public void RegisteringAGenericBinderShouldEnableResolution()
    	{
    		var fixture = new Fixture();
    		fixture.Inject<IX>( fixture.Freeze<X>() );
    		fixture.RegisterOpenGenericImplementation( typeof( IOGF<> ), typeof( OGF<> ) );
    
    		Assert.IsType<OGF<C>>( fixture.CreateAnonymous<D>().Ogf );
    	}
    }
