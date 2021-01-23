    var dictionary = Assembly.GetExecutingAssembly().GetTypes().
        Select(t => new { t, Attribute = t.GetCustomAttribute(typeof(MyEnumAttribute)) }).
        Where(e => e.Attribute != null).
        ToDictionary(e => (e.Attribute as MyEnumAttribute).Value, 
                     e => ConstructorFactory.Create<object>(e.t));
    var wanted = MyEnum.Reset;
    var instance = dictionary[wanted]();
