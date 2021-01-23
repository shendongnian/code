    string input = "MyClass";
    var type = Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .FirstOrDefault(t => t.Name == input);
    MyClass myObject = (MyClass)Activator.CreateInstance(type);
