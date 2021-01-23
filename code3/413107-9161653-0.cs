    public class TestClass
    {
        readonly Func<Foo> _fooFactory;
    	
        public TestClass(Func<Foo> fooFactory)
        {
            _fooFactory = fooFactory;
        }
    	
    	public void LoadFoo()
    	{
    		var foo = _fooFactory(); // This hides the call container.Resolve<Foo>()
			// Do something with foo
    	}
    }
