    List<MyPropertyClass> objList = new List<MyPropertyClass>();
    objList.Add(new MyPropertyClass());
    objList.Add(new MyPropertyClass());
    AnotherPropertyClass obj = new AnotherPropertyClass();
    obj.GetType().GetProperty("ArrayProperty").SetValue(obj, objList.ToArray());
