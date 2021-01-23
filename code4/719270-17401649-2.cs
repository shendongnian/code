    public string Baz()
    {
        return Baz(GlobalVariable);
    }
    
    public string Baz(string globalVar)
    {
        return globalVar + "qux";
    }
