    ObjectQuery pageFileUsageQuery = 
            new ObjectQuery("SELECT AllocatedBaseSize, CurrentUsage FROM Win32_PageFileUsage");
    using(m_PageFileUsageSearcher = new ManagementObjectSearcher(managementScope, pageFileUsageQuery))
    {
    	...
    	using(var pageFileUsageCollection = m_PageFileUsageSearcher.Get())
    	{
    		double currentUsage = 0;
    		double maxSize = 0;
    		
    		foreach (ManagementBaseObject managementBaseObject in pageFileUsageCollection)
    		{
    			try
    			{
    				string result = managementBaseObject["CurrentUsage"].ToString();
    				currentUsage += double.Parse(result);
    			}
    			finally
    			{
    				managementBaseObject.Dispose();
    			}
    		}
    	}
    }
