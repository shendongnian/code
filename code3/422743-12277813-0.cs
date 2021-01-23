    protected Dictionary<int, string> myDict = new Dictionary<int, string>(); 
    protected Dictionary<int, string> MyDict
    {
        get
        {
            return myDict ?? (myDict = new Dictionary<int, string>());
        }
    }
        
