    class A 
    {
    	protected void Method() {}
    }
    
    class B : A
    {
    	public void Foo()
    	{
    		Method(); // works!
    	}
    }
    
    class C 
    {
    	public void Foo()
    	{
    		Method(); // won't work, obviously
    		
    		var tmp = new A();
    		tmp.Method(); // won't work either because its protected
    	}
    }
