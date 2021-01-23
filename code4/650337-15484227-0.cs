    BitmapPropertySet properties = await encoder.BitmapProperties.GetPropertiesAsync("/appext/Data");
    properties = new BitmapPropertySet()
    {
    	{
    		"/appext/Application",
    		new BitmapTypedValue(Iso8859.Default.GetBytes("NETSCAPE2.0"), Windows.Foundation.PropertyType.UInt8Array)
    	},
    	{ 
    		"/appext/Data",
    		new BitmapTypedValue(new byte[] { 3, 1, 0, 0, 0 }, Windows.Foundation.PropertyType.UInt8Array)
    	},
    };
    
    await encoder.BitmapProperties.SetPropertiesAsync(properties);
