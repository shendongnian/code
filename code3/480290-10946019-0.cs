    class A
    {    
    	protected int i = 13;    
    }
    
    class B : A
    {
    	protected new int i = 9;
    
    	public void fun()
    	{
    		Console.Write(base.i);
    	}
    }
