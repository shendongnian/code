    public string Baz(string globalVar = null)
    {
        if(string.IsNullOrEmpty(globalVar))
            globalVar = GlobalVariable;
        return globalVar + "qux";
    }
