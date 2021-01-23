    public static Collection<T> func_name<T>(T param)
    {
    }
    
    private static void Main(string[] args)
    {
    	string paramAsString = string.Empty;
    	
    	// Type inference here: the compiler know which is the type
    	// represented by T as the parameter of the method that must 
    	// be of type T is a string (so, for the compiler, T == string)
    	// That's why in this example it's not required to write:
    	// var obj = func_name<string>(paramAsString);
        // but following is enough:
        // var obj = func_name(paramAsString);
    	Collection<string> obj = func_name(paramAsString);
    
    	Console.ReadLine();
    }
