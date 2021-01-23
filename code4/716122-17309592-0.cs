    public void Method_1(string arg1, string arg2)
    {
       /*
       //some code implementation specific to Method_1
       */
       var dict = GetArguments(args);
       Method_2(dict);
    }
    
    private Dictionary<string, object> GetArguments(List<string> args)
    {
    	Dictionary<string, object> dict= new Dictionary<string, object>();
       var counter = 1;
       foreach(var argItem in args)
       {
            dict.Add("Arg"+counter++, argItem);
       }
       return dict;
    }
