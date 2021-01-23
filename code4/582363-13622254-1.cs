    //initialization
    Dictionary<Type, Action> typeActions = new Dictionary<Type, Action>();
    typeActions.Add(typeof (MyClass), () => {Console.WriteLine("MyClass");});
    typeActions.Add(typeof (MyClass2), () => {Console.WriteLine("MyClass2");});
    private void TestGeneric<T>(T val)
    {
       Action action = typeActions[val.GetType()];
       action();
    }
    
