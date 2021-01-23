    public class FunctionResponse
    {
    	public string FunctionResult { get; set; }
    }
    
    public void Test()
    {
    	var serialized = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <FunctionResponse>   
    	<FunctionResult>&lt;gml&gt;data&lt;/gml&gt;</FunctionResult>
    </FunctionResponse>";
    	var ser = new XmlSerializer(typeof(FunctionResponse));
    	using (var stringReader = new StringReader(serialized))
    	{
    		using (var xmlReader = new XmlTextReader(stringReader))
    		{
    			var response = ser.Deserialize(xmlReader);                    
    		}
    	}            
    }
