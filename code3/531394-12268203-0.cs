    class A : IDisposable
    {
    	public static event Action OnInvalidated;
    
    	public A()
    	{
    		A.OnInvalidated +=  this.SomeMethod();
    		A.OnInvalidated +=  this.SomeOtherMethod();
    	}
    
        	public void Dispose()
        	{
    		A.OnInvalidated -=  this.SomeMethod();
    		A.OnInvalidated -=  this.SomeOtherMethod();
        	}
    
    	public SomeMethod()
    	{
    
    	}
    
    	public SomeOtherMethod()
    	{
    
    	}
    }
