    public void ActionOnMatch(string input, string pattern, Action<string> action)
    {
        var m = Regex.Match(input, pattern);
        if(m.Success)
        {
            action(m.Value);
        }
    }
    
    public TResult FuncOnMatch<TResult>(string input, string pattern, 
        Func<string, TResult> func)
    {
        var m = Regex.Match(input, pattern);
        if(m.Success)
        {
            return func(m.Value);
        }
        else
        {
            return default(TResult);
        }
    }
    /// usage
    string pattern = @"a pattern to match"; 
    ActionOnMatch(input, pattern, DoSomething);
    var result = FuncOnMatch<string>(input, pattern, (val) => val);
