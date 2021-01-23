    void Main()
    {
    var sample = new
    		{
    			Time = DateTime.Now,
    			Name = "Hello",
    		};
    	sample.ToAnonString(()=>sample.Name).Dump();
    }
    public static class ovs{
    	   public static string ToAnonString(this object o,Func<string> exp){
    		 return exp();
    	   }
    	}
