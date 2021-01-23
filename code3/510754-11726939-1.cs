    IColor desiredColor = //whatever
    int desiredNumber = //whatever
    Dictionary<string, object> arguments = new Dictionary<string, object>();
    arguments.Add("c", desiredColor);
    arguments.Add("somenumber", desiredNumber);
    IFoo foo = container.Resolve<IFoo>(arguments);
    
