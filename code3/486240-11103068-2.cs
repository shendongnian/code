    public Func<dynamic, string> ConvertToDynamicFunc<T>(Func<T, string> typedFunc)
    {
    	Func<dynamic, string> dynamicFunc = (input) =>
    	{
    		if (input is T)
    			return typedFunc((T)input);
    		return null; //or throw?
    	};
    	
    	return dynamicFunc;
    }
    
    Func<int, string> typedFunc = (input) => input.ToString();
    Func<dynamic, string> dynamicFunc = ConvertToDynamicFunc(typedFunc);
    System.Console.WriteLine(dynamicFunc(10));//outputs "10";
    System.Console.WriteLine(dynamicFunc(10.5));//outputs null since a double isn't an int (type T) or throw if you prefer;
