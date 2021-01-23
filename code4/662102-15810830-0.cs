    public class Test
    {    
    	private object syncRoot = new object();
    	
    	private void Foo()
    	{
    		lock (this.syncRoot)
    		{
    			....
    		}
    	}
    }
