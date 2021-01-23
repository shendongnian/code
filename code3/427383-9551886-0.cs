    public IEnumerable<string> Something
    {
        get
        {
            var x = MethodBase.GetCurrentMethod().Name;
            return this.DoSomething(x);
        }
    }
    private IEnumerable<string> DoSomething(string x)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return x;
        }
    }
