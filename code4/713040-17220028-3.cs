    var result = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Parent));
    foreach(Type type in result)
    {
        dict["key" + n] = type;
        n++;
    }
