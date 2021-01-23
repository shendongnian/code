    //Populate a dictionary with Reflection
    var dictionary = Assembly.GetExecutingAssembly().GetTypes().
        Select(t => new {t, Attribute = t.GetCustomAttribute(typeof (MyEnumAttribute))}).
        Where(e => e.Attribute != null).
        ToDictionary(e => (e.Attribute as MyEnumAttribute).Value, e => e.t);
    //Assume that you dynamically want an instance of ResetClass
    var wanted = MyEnum.Reset;
    var instance = Activator.CreateInstance(dictionary[wanted]);
    //The biggest downside is that instance will be of type object.
    //My solution in this case was making each of those classes implement
    //an interface or derive from a base class, so that their signatures
    //would remain the same, but their behaviors would differ.
