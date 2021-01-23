    object obj = new D { c = new C { b = new B { a = new A { i = 1 } } } };
    List<string> path = new List<string> { "c", "b", "a", "i" };
    object value = 42;
    
    FieldInfo fieldInfo = null;
    object prevObj = null;
    object obj2 = obj;
    for (int i = 0; i < path.Count; i++)
    {
        string fieldName = path[i];
        fieldInfo = obj2.GetType().GetField(fieldName);
        if (i == path.Count - 1) prevObj = obj2;
        obj2 = fieldInfo.GetValue(obj2);
    }
    if (fieldInfo != null)
    {
        fieldInfo.SetValue(prevObj, value);
    }
    Console.WriteLine(((D)obj).c.b.a.i == (int) value);
