    class App
    {
        static void Main()
        {
    	    B classb = new B(1,2,3);
            classb.blah(4);
        }
    }
    
    class A
    {
    	public A(int a, int b, int c)
    	{
    	}
    }
    class B : A 
    {
    	public B(int a, int b, int c): base (a, b, c)
    	{
    	}
    	
    	public void blah(int something)
    	{
    		Console.WriteLine(something);
    	}
    }
