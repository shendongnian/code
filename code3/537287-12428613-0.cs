    public enum Days : short
    {
        Monday = 1,
        Tuesday = 2,
        ...
    }
    
    DoSomething(Days.Monday);
    void DoSomething(Days day)
    {
        Days nextDay = day + 1;
    }
