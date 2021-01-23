    using System.Runtime.CompilerServices;
    using System.Threading;
    
    public class MessageBuffer
    {
    	// Shared resources up here
    
    	public MessageBuffer()
    	{
    		// Initiating the shared resources
    	}
    
    	[MethodImpl(MethodImplOptions.Synchronized)]
    	public virtual void post(object obj)
    	{
    		// Do stuff
    		Monitor.Wait(this);
    		// Do more stuff
    		Monitor.PulseAll(this);
    		// Do even more stuff
    	}
    
    	[MethodImpl(MethodImplOptions.Synchronized)]
    	public virtual object fetch()
    	{
    		// Do stuff
    		Monitor.Wait(this);
    		// Do more stuff
    		Monitor.PulseAll(this);
    		// Do even more stuff and return the object
    	}
    }
