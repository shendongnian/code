    public Task<List<string>> foo()
    {
        return new Task<List<string>>(ReturnList);
    }
    List<string> ReturnList()
    {
        //Do some work
        Thread.Sleep(1000);
        //Return the result
        return new List<string>();
    }
