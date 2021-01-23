    // Load the assembly
    Assembly a = Assembly.LoadFile(@"C:\Path\To\Your\DLL.dll");
    // Load the type and create an instance
    Type t = a.GetType("ClassLibrary1.Calculator");
    object instance = a.CreateInstance("ClassLibrary1.Calculator");
    // Call the method
    MethodInfo m = t.GetMethod("Calc");
    m.Invoke(instance, new object[] {}); // Get the result here
