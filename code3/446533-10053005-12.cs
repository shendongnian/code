    public void Test2() { 
        var list = GetMyClassList(); 
        var validPartTypes = list 
            .SelectMany(mc => mc.Keys.ToDictionary(k => mc)) 
            .ToDictionary(); 
    } 
