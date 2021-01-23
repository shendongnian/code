    class Foo : IFoo
    {
    	public Foo(IBar bar)
    	{
    		bar.Foo = this; 
    	}
    }
    
    interface IBar
    {
    	IFoo Foo { get; set; }
    }
    
    class Bar : IBar
    {
    	public IFoo Foo { get; set; }
    }
    
    // usage
    container.Register<IFoo>(c => new Foo(c.Resolve<IBar>()));
