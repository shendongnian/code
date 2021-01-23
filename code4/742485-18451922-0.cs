    System.Func<float, string> sysFunc = this.MyFunction;
    string s = sysFunc.Method.Name; // prints "MyFunction"
    
    public string MyFunction(float number)
    {
        return "hello world";
    }
