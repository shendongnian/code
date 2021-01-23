    public static Type LoadSomething(string assemblyQualifiedName)
    {
    	// This will return null
    	// Just here to test that the simple GetType overload can't return the actual type
    	var t0 = Type.GetType(assemblyQualifiedName);
    
    	// Throws exception is type was not found
    	return Type.GetType(
    		assemblyQualifiedName,
    		(name) =>
    		{
    			// Returns the assembly of the type by enumerating loaded assemblies
    			// in the app domain			
    			return AppDomain.CurrentDomain.GetAssemblies().Where(z => z.FullName == name.FullName).FirstOrDefault();
    		},
    		null,
    		true);
    }
    
    private static void Main(string[] args)
    {
    	// Dynamically loads an assembly
    	var assembly = Assembly.LoadFile(@"C:\...\ClassLibrary1.dll");
    
    	// Load the types using its assembly qualified name
    	var loadedType = LoadSomething("ClassLibrary1.Class1, ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    
    	Console.ReadKey();
    }
