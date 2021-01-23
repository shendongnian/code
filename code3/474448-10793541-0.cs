    public class ThreadSafeCounter
    {
    	private object _lockObject = new Object();  // Initialise once
    	private int count = 0; 
    	public void Increment()
    	{
    		lock(_lockObject) // Only one thread touches count at a time
    		{ 
    			count++; 
    		}
    	} 
    	public void Decrement()
    	{
    		lock (_lockObject) // Only one thread touches count at a time
    		{
    			count--; 
    		}
    	} 
    	public int Read()
    	{
    		lock (_lockObject) // Only one thread touches count at a time
    		{
    			return count; 
    		}
    	}
    }
