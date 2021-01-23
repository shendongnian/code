    class A
    {    
    	protected int i = 13;    
    }
    
    class B : A
    {
    	public B()
    	{
    		i = 9;
    	}
    
    	public void fun()
    	{
    		Console.Write(i);
    	}
    }
