    protected void Process(List<SomeClass> mylist, List<Action<SomeClass>> actions)
    {
        foreach (var item in mylist)
        {
            if (!SomeClass.Validate(item)) 
            { 
                continue; 
            }
            foreach(var action in actions) 
                action(item); 
        }
    }
