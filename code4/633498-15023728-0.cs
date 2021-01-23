    public MyRetType MyMethod() 
    {
        return MyMethod(null,null);
    }
    
    public MyRetType MyMethod(String p1) 
    {
        return MyMethod(p1,null);
    }
    
    public MyRetType MyMethod(String p1, IEnumerable<int>)
    {
        MyMethod(<default values>);
    } 
