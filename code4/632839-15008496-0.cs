    class Foo
    {
    	private static bool ShouldOnlyExecuteOnceExecuted = false;
    	private static readonly object Locker = new object();
    	
    	public Foo(string bar)
    	{
    		SetShouldOnlyExecuteOnce(bar);
    	}
    	
    	private void SetShouldOnlyExecuteOnce(string bar)
    	{
    		if(!ShouldOnlyExecuteOnceExecuted)
    		{
    			lock(Locker)
    			{
    				if(!ShouldOnlyExecuteOnceExecuted)
    				{
    					ShouldOnlyExecuteOnce(bar);
    					ShouldOnlyExecuteOnceExecuted = true;
    				}
    			}
    		}
    	}
    }
