    public static void HandleOptimisticConcurrencyException(ObjectContext context, OptimisticConcurrencyException ex)
    {
    	string msg = @"The data has changed while you were editing it.
    If you save, your changes will override the previous ones.
    If you don't, your changes will be lost.
    
    Do you want to save your changes ?";
    
    	var ret = System.Windows.MessageBox.Show(msg, "Concurrency error...", MessageBoxButton.YesNo, MessageBoxImage.Warning);
    
    	if (ret ==  MessageBoxResult.Yes)
    	{
    		if (ex.StateEntries != null)
    		{
    			foreach (var item in ex.StateEntries)
    			{
    				context.Refresh(RefreshMode.ClientWins, item.Entity);
    			}
    		}
    	}
    	else
    	{
    		if (ex.StateEntries != null)
    		{
    			foreach (var item in ex.StateEntries)
    			{
    				context.Refresh(RefreshMode.StoreWins, item.Entity);
    			}
    		}
    	}
    
    	do
    	{
    		try
    		{
    			context.SaveChanges();
    			break;
    		}
    		catch (OptimisticConcurrencyException ex2)
    		{
    			if (ret == MessageBoxResult.Yes)
    			{
    				foreach (var item in ex2.StateEntries)
    				{
    					context.Refresh(RefreshMode.ClientWins, item.Entity);
    				}
    			}
    			else
    			{
    				foreach (var item in ex2.StateEntries)
    				{
    					context.Refresh(RefreshMode.StoreWins, item.Entity);
    				}
    			}
    		}
    	}
    	while (true);
    }
