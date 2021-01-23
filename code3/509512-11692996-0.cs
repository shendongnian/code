    public static List<int> DoSomethingWithList(List<int> list)
    {
        //do stuff
        return list;
    }
    
    public static List<int> DoSomethingElseWithList(List<int> list)
    {
        //do other stuff
        return list;
    }
    
    public static void Main(string[] args)
    {
        var list = new List<int>() { 1, 2, 3, 4 };
        list = DoSomethingWithList(list); //change list
        list = DoSomethingElseWithList(list); //change list further
    }
