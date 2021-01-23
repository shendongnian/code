    public void Test(Type type)
    {
        dynamic myVariable = Activator.CreateInstance(type);          
        // do something, like use myVariable and call a method: myVariable.MyMethod(); ...
    }
