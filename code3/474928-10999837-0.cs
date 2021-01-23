    public XmlDocument GetXml()
    {
            XmlDocument retValue = new XmlDocument();
    		try
    		{
    		        XmlSerializer xs = new XmlSerializer(this.GetType()); 
    			Stream stream = new MemoryStream();
    			xs.Serialize( stream, toSerialize );
    			stream.Position = 0;
    			retValue.Load( stream );
    		}
    		catch (Exception ex)
    		{
    		}
    	return retValue;
    }
