    public class WaitGroup
    {
    	long _count;
    
    	public WaitGroup() { _count = 0; }
    
    	public void Add() { Interlocked.Increment(ref _count); }
    	public void Done() { if (Interlocked.Decrement(ref _count) < 0) throw new InvalidOperationException("Done called for this WaitGroup more than Add"); }
    
    	long Count { get { return Interlocked.Read(ref _count); } }
    	public void Wait() { Wait(TimeSpan.MaxValue); }
    	public bool Wait(TimeSpan timeout)
    	{
    		var res = false;
    
    		var spin = new SpinWait();
    		var time = new Stopwatch();
    		time.Start();
    
    		while (!(res = Count == 0) && time.Elapsed <= timeout)
    		{
    			if (res)
    			{
    				break;
    			}
    			spin.SpinOnce();
    		}
    
    		return res;
    	}
    
    	public bool WaitAfterFirst() { return WaitAfterFirst(TimeSpan.MaxValue); }
    	public bool WaitAfterFirst(TimeSpan timeout)
    	{
    		var res = false;
    
    		var spin = new SpinWait();
    		var time = new Stopwatch();
    		time.Start();
    
    		while (!(res = Count > 0) && time.Elapsed <= timeout)
    		{
    			if (res)
    			{
    				break;
    			}
    			spin.SpinOnce();
    		}
    
    		return res;
    	}
    }
