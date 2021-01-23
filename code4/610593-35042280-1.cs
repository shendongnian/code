    public static class ExtMethods
    {
    	public static object Dumpable(this JToken t)
    	{
    		if(t is JObject)
            {
                var json = JsonConvert.SerializeObject(t);
    			return JsonConvert.DeserializeObject<ExpandoObject>(json);
            }
    		else if(t is JArray)
            {
    			return (t as JArray).Select(Dumpable);
            }
    		else if(t is JValue)
            {
    			return t.ToString();
            }
    		else if(t is JProperty)
            {
                var p = (t as JProperty);
    			return new { Name=p.Name, Value=Dumpable(p.Value) };
            }
    		else
            {
    			throw new Exception("unexpected type: " + t.GetType().ToString());
            }
    	}
    	
    	public static JToken DumpPretty(this JToken t)
    	{
    		t.Dumpable().Dump();
    		return t;
    	}
    }
    
    public static object Dumpable(JToken t)
    {
    	return t.Dumpable();
    }
