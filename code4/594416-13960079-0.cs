    public Task<List<string>> foo()
    {
        return new Task<List<string>>(ReturnList);
    }
    List<string> ReturnList()
    {
        //Operate
    }
