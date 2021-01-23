    private const string DEFAULT_INPUT = "Default Input"; // protected if in base class
    public void Work(string input = DEFAULT_INPUT)
    {
        //do stuff
    }
    public void WorkWrapper(int someParameter, string input = DEFAULT_INPUT)
    {
        //do initialization
        Work(input);    
    }
