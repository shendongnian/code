    private void InvokeLoadDevices()
    {
    	// Get list of physical and logical devices
    	List<PhysicalDevice> devices = GetDiskDevices();
    
    	// Check if calling this method is not thread safe and calling Invoke is required
    	if (trvDevices.InvokeRequired)
    	{
    		trvDevices.Invoke((MethodInvoker)(() => LoadDevices(devices)));
    	}
    	else
    	{
    		LoadDevices(devices);
    	}
    }
