    class Class1{ }
    class Class2{ }
    class Class3{ }
    
    void Main()
    {
        var possibleTypes = new Type[]
        {
            typeof(Class1),
            typeof(Class2),
            typeof(Class3)
        };
        Type t = possibleTypes[(new Random()).Next(possibleTypes.Length)];
        object instance = Activator.CreateInstance(t);
        if (t.Equals(typeof(Class1)))
        {
            DoSomethingWithClass1(instance as Class1);
        }
        else if (t.Equals(typeof(Class2)))
        {
            DoSomethingWithClass2(instance as Class2);
        }
        else if (t.Equals(typeof(Class3)))
        {
            DoSomethingWithClass3(instance as Class3);
        }
    }
    
    void DoSomethingWithClass1(Class1 instance)
    {
        //...
    }
    
    void DoSomethingWithClass2(Class2 instance)
    {
        //...
    }
    
    void DoSomethingWithClass3(Class3 instance)
    {
        //...
    }
