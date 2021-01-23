    public void DoSomething( .... , bool orderByX)
    {
        var query = ... ;
        if (orderByX)
            query = ... .OrderBy(x => x.Location.X);
        else
            query = ... .OrderBy(x => x.Location.Y);
        
        foreach(var x in query) // deferred execution
        {
           ...
        }
    }
