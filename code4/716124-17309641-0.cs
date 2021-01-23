    public void Method_1(string arg1, string arg2)
    {
        var dict = BuildDictionary(arg1, arg2);
        Method_2(dict);
    }
    private Dictionary<string, object> BuildDictionary(params object[] args)
    {
        Dictionary<string, object> dict= new Dictionary<string, object>();
        for(int i = 0; i < args.Length; i++)
        {
            dict.Add("Arg" + i, args[i]);
        }
        return dict;
    }
