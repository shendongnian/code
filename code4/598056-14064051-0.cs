    public static class MyDict_String 
    {
    	public static string Value { get; set; }
    }
    
    public static class MyDict_Int32
    {
    	public static int Value { get; set; }
    }
    
    MyDict_String.Value = MyDict_Int32.Value.ToString();
