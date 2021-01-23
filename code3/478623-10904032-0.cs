    void DoWork(string parameter1, string parameter2, Func<string, string, TResult> customCode) {
    	//Common code 
    	var customResult = customCode(parameter1, parameter2);
    	//Common code 
    }
