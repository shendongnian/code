    public class B
    {
    	//has access to A but can not create C. Must ask A to create C.
    	private void method()
    	{
    		var a = new C.A();
    		var c = a.GetC();//Ok!
    		var c2 = new C();//Not allowed.
    	}
    }
    
    public class C
    {
    	private C()
    	{
    	}
    	
    	public class A
    	{
    		public C GetC()
    		{
    			return new C();
    		}
    	}
    }
