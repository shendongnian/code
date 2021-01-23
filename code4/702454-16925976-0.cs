    public class A
    {
    	public string result;
    
    	public A(int case)
    	{
    		if(case == 0)
    		{
    			this.result = "a0"; 
    		}
    		else if(case == 2)
    		{
    			this.result = "a2";
    		}
    		else
    		{
    			return new B(case).result;
    		}
    	}
    }
    
    public class B
    {
    	public string result;
    
    	public B(int case)
    	{
    		if(case == 0)
    		{
    			this.result = "b0"; 
    		}
    		else if(case == 2)
    		{
    			this.result = "b2"
    		}
    		else
    		{
    			return new C(case).result;
    		}
    	}
    }
    
    public class C
    {
    	public string result;
    
    	public C(int case)
    	{
    		if(case == 0)
    		{
    			this.result = "C0"; 
    		}
    		else
    		{
    			this.result = "c1";
    		}
    	}
    }
