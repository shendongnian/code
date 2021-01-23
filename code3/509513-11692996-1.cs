    public List<int> DoSomethingWithList(List<int> list)
    {
        //do stuff
        return list;
    }
    
    public List<int> DoSomethingElseWithList(List<int> list)
    {
        //do other stuff
        return list;
    }
    
    public void SomeOtherFunction(string[] args)
    {
        var list = new List<int>() { 1, 2, 3, 4 }; //create list
        list = DoSomethingWithList(list); //change list
        list = DoSomethingElseWithList(list); //change list further
    }
