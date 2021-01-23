    interface IA
    {
    	void Method1();
    	void Method2();
    }
    
    class A : IA
    {
    	// Implicit implementation
    	public void Method1()
    	{
    	}
    
    	// Explicit implementation
    	void IA.Method2()
    	{
    	}
    }
    
    class TestImplicitExplicit
    {
    	public void Test( )
    	{
    		A a = new A();
    		a.Method1(); // ok
    		//a.Method2(); // does not compile
    
    		IA ia = a;
    		ia.Method1(); // ok
    		ia.Method2(); // ok
    	}
    }
