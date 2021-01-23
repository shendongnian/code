    [Suite] 
    public static IEnumerable Suite
    {
        get
        {
            ArrayList suite = new ArrayList();
            suite.Add(new AddAll());
            suite.Add(new RemoveAll());
            return suite;
        }
    }
