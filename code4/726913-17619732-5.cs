    public static class XmlConfigSerializer
    	{
    				
    		public static Config DeSerialize()
    		{
    				try 
    				{	        
    					if (!File.Exists("config.xml")) { return null; }
    
    					XmlSerializer serializer = new XmlSerializer(typeof(Config));
    					using (var fs = new FileStream("config.xml", FileMode.Open))
    					{
    						return (Config) serializer.Deserialize(fs);
    					}					
    				}
    				catch (Exception ex)
    				{
    					//log error
    					return null;
    				}
    		}
    
    		public static void Serialize(Config config)
    		{
    			XmlSerializer serializer = new XmlSerializer(typeof(Config));
    			using (var fs = new FileStream("config.xml", FileMode.Create))
    			{
    				serializer.Serialize(fs, config);
    			}
    		}
    	}
