    static void Main(string[] args)
    {
    	//
    	// 1. Load assembly "MyAssembly.dll" from file path. Specify that we will be using class MyAssembly.MyClass
    	//
    	Assembly asm = Assembly.LoadFrom(@"C:\Path\MyAssembly.dll");
    	Type t = asm.GetType("MyAssembly.MyClass");
    
    	//
    	// 2. We will be invoking a method: 'public int MyMethod(int count, string text)'
    	//
    	var methodInfo = t.GetMethod("MyMethod", new Type[] { typeof(int), typeof(string) });
    	if (methodInfo == null)
    	{
    		// never throw generic Exception - replace this with some other exception type
    		throw new Exception("No such method exists.");
    	}
    
    	//
    	// 3. Define parameters for class constructor 'MyClass(int initialX, int initialY)'
    	//
    	object[] constructorParameters = new object[2];
    	constructorParameters[0] = 999; // First parameter.
    	constructorParameters[1] = 2;   // Second parameter.
    
    	//
    	// 4. Create instance of MyClass.
    	//
    	var o = Activator.CreateInstance(t, constructorParameters);
    
    	//
    	// 5. Specify parameters for the method we will be invoking: 'int MyMethod(int count, string text)'
    	//
    	object[] parameters = new object[2];
    	parameters[0] = 124;            // 'count' parameter
    	parameters[1] = "Some text.";   // 'text' parameter
    
    	//
    	// 6. Invoke method 'int MyMethod(int count, string text)'
    	//
    	var r = methodInfo.Invoke(o, parameters);
    	Console.WriteLine(r);
    }
