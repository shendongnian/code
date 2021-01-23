    ConcurrentDictionary<string, MyInterface> myClass1Dict = new ConcurrentDictionary<string, MyInterface>();
    myClass1Dict.TryAdd("one", new MyObject());
    myClass1Dict.TryAdd("two", new MyObject());
    ConcurrentDictionary<string, MyInterface> myClass2Dict = new ConcurrentDictionary<string, MyInterface>();
    myClass1Dict.TryAdd("one", new Variable());
    myClass1Dict.TryAdd("two", new Variable());
    ConcurrentDictionary<Type, ConcurrentDictionary<string, MyInterface>> objectDict = new ConcurrentDictionary<Type, ConcurrentDictionary<string, MyInterface>>();
    objectDict.TryAdd(Type.GetType(MyObject), myClass1Dict);
    objectDict.TryAdd(Type.GetType(Variable), myClass2Dict);
