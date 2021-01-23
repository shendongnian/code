    public static class MyClass : BlockTableRecord
    {
        public static string Id {get;set;}
    }
    public static class UsingStaticClass 
    {
    	public static void setIdWithValue(string[] args) 
    	{
                 MyClass.Id = 2;
    	}
    
        public static void RetrieveIdValue()
        {
               var someOtherValue = MyClass.Id;
        }
    }
        
