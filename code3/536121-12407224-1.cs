    public string MyCallingMethod()
    {
        string result = myMethodAsync().Result;
        return result;
    }
