    [AttributeUsage(AttributeTargets.Field)]
    public class LocalDescription : Attribute
    {
    	public LocalDescription (string cc, string rk)
    	{
    		CultureCode = cc;
    		ResourceKey = rk;
    	}
    	public string CultureCode{get;set;}
    	public string ResourceKEy{get;set;}
    
    }
