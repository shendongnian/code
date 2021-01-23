    IEnumerable<string> result;
    
    public void Test()
    {
       SomeMethod(out result);
    }
    
    public void SomeMethod(out string[] someArray)
    {
       someArray = new string[];
       ChangeTheType();
       int n = someArray.Length;    // BANG!! - someArray is now a List<string>
    }
    
    public void ChangeTheType()
    {
        result = new List<string>();
    }
