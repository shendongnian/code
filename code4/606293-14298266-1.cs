    static void Handle(Exception e)
    {
        var exceptionType = e.GetType();
        //Use an if/else block, or use a Dictionary<Type, Action>
        //to operate on your exception
        Logger.log(exceptionType + " " + e);
        DoSomething();
    }
