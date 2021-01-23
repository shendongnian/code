    	private void ReadResxFile(string filename)
	    {
	      	if (System.IO.File.Exists(filename))
		   {
		    	using (ResXResourceReader reader = new ResXResourceReader(filename))
		    	{
		    		//TODO
		    	}
    		}
    	}
    	public void SaveResxAs(string fileName, string key, string value)
    	{
    		try
    		{
    			using (ResXResourceWriter writer = new ResXResourceWriter(fileName))
    			{
    				writer.AddResource(key, value);
    				writer.Generate();
    			}
    		}
    		catch (Exception error)
    		{
    			throw error;
    		}
    	}
