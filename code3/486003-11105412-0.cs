    public abstract class PluginBase : IPlugin
    {
    
    	public void Execute(IServiceProvider serviceProvider)
    	{
    		try
    		{
    			OnExecute(serviceProvider);
    		}
    		catch (Exception ex)
    		{
    			bool rethrow = false;
    			try
    			{
    				OnError(ex);
    			}
    			catch
    			{
    				rethrow = true;
    			}
    	
    			if (rethrow)
    			{
    				throw;
    			}
    		}
    		finally
    		{
    			OnCleanup();
    		}
    	}
    	
    	// method is marked as abstract, all inheriting class must implement it
    	protected abstract void OnExecute(IServiceProvider serviceProvider);
    	
    	// method is virtual so if an inheriting class wishes to do something different, they can
    	protected virtual void OnError(Exception ex){
    		// Perform logging how ever you log:
    		Logger.Write(ex);
    	}
    	
    	/// <summary>
    	/// Cleanup resources.
    	/// </summary>
    	protected virtual void OnCleanup()
    	{
    		// Allows inheriting class to perform any cleaup after the plugin has executed and any exceptions have been handled
    	}
    }
