    public class Parameters
    {
    	private static Dictionary<int, object> paramList =
            new Dictionary<int, object>();
    
    	public static void save(int hash, object value)
    	{
    		if (!paramList.ContainsKey(hash))
    			paramList.Add(hash, value);
    	}
    
    	public static object request(int hash)
    	{
    		return ((KeyValuePair<int, object>)paramList.
                        Where(x => x.Key == hash).FirstOrDefault()).Value;
    	}
    }
