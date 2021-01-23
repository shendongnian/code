    public object Deserialize(string filePath, Type type)
    {
    	Stream stream = null;
    
    	try
    	{
    		stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    		XmlSerializer serializerObj = new XmlSerializer(type);
    
    		return serializerObj.Deserialize(stream);
    	}
    	catch (Exception)
    	{
    		// Put something useful here
    		throw;
    	}
    	finally
    	{
    		if (stream != null)
    		{
    			stream.Close();
    		}
    	}
    }
