    // will load the assembly
    Assembly myAssembly = Assembly.LoadFile(Environment.CurrentDirectory + "\\MyClassLibrary.dll");
    // get the class. Always give fully qualified name.
    Type ReflectionObject = myAssembly.GetType("MyClassLibrary.ReflectionClass");
    // create an instance of the class
    object classObject = Activator.CreateInstance(ReflectionObject);
    // set the property of Age to 10. last parameter null is for index. If you want to send any value for collection type
    // then you can specify the index here. Here we are not using the collection. So we pass it as null
    ReflectionObject.GetProperty("Age").SetValue(classObject, 10,null);
    // get the value from the property Age which we set it in our previous example
    object age = ReflectionObject.GetProperty("Age").GetValue(classObject,null);
    // write the age.
    Console.WriteLine(age.ToString());
