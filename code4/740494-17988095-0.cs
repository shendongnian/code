    void Main()
    {
        TestClass t=new TestClass();
        t.Address="address";
        t.ID=132;
        t.Name=string.Empty;
        t.DateTime=null;
	
    	t.Dump();
    	var ret = t.FixMeUp();
    	((object)ret).Dump();
    }
    public static class ReClasser
    {
    	public static dynamic FixMeUp<T>(this T fixMe)
    	{
    		var t = fixMe.GetType();
    		var returnClass = new ExpandoObject() as IDictionary<string, object>;
    		foreach(var pr in t.GetProperties())
    		{
    			var val = pr.GetValue(fixMe);
    			if(val is string && string.IsNullOrWhiteSpace(val.ToString()))
    			{
    			}
    			else if(val == null)
    			{
    			}
    			else
    			{
    				returnClass.Add(pr.Name, val);
    			}
    		}
    		return returnClass;
    	}
    }
    
    public class TestClass
    {
    	public string Name { get; set; }
        public int ID { get; set; }
        public DateTime? DateTime { get; set; }
        public string Address { get; set; }
    }
