    var names = binder.CallInfo.ArgumentNames;
    var numberOfArguments = binder.CallInfo.ArgumentCount;
    var numberOfNames = names.Count;
    
    var namesStartingIndex = numberOfArguments - numberOfNames;
    
    commands.Add(binder.Name);
    for (var i = 0; i < numberOfArguments; i++ )
    {
        if (i < namesStartingIndex)
        {
            arguments.Add(new Argument(args[i]));
            continue;
        }
        arguments.Add(new Argument(names[i-namesStartingIndex], args[i]));
    }
