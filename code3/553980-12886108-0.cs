    Assembly asm = Assembly.GetExecutingAssembly(); // or whatever assembly object
    Type[] types;
    try
    {
      types = Assembly.GetTypes();
    }
    catch (TypeLoadException e) // or ReflectionTypeLoadException
    {
      types = e.Types.Where(t => t != null).ToArray();
    }
