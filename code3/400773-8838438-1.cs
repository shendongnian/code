    interface IA
    {
    	void Method1();
    	void Method2();
    	void Method3();
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
    	// Implicit + explicit implementation!
    	public void Method3()
    	{
    	}
    
    	void IA.Method3()
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
    		a.Method3(); // ok
    
    		IA ia = a;
    		ia.Method1(); // ok
    		ia.Method2(); // ok
    		ia.Method3(); // ok (calls another method than a.Method3(); !)
    	}
    }
