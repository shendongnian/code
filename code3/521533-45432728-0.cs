    class A
    {
    	static A()
    	{
    		Console.WriteLine("Static A.");
    	}
    	
    	public A()
    	{
    		Console.WriteLine("Non-Static A.");
    	}
    }
    
    class B : A
    {
    	static B()
    	{
    		Console.WriteLine("Static B.");
    	}
    	
    	public B()
    	{
    		Console.WriteLine("Non-Static B.");
    	}
    }
    	
    void Main()
    {
    	new B();
    }
    Static B.
    Static A.
    Non-Static A.
    Non-Static B.
