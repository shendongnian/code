    public static class Super
    {
    	public static class Sub
    	{
    		public static string OtherValue {get{return SomeValue;}}
    	        
                // Remove this line and OtherValue will return Outer
    		public static string SomeValue { get{return "Inner"; }}
    	}
    
    	public static string SomeValue { get{return "Outer"; }}
    }
