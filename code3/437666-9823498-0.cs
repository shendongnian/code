    interface Interface1
    {
    	void Method1();   
    }
    
    interface Interface2 : Interface1
    {
    	void Method2();
    }
    
    class Class1 : Interface1
    {
    	public void Method1()
    	{
    	}
    }
    
    class Class2 : Class1, Interface2
    {
    	public void Method2()
    	{
    	}
    }
