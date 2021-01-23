    var stringType = Type.GetType("System.String");
    var listType = typeof (List<>);
    var stringListType = listType.MakeGenericType(stringType);
    var list = Activator.CreateInstance(stringListType) as IList;
    
    list.Add("Foo");
    list.Add("Bar");
    list.Add("Baz");
