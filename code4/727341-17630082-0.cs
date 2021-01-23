    var assembly = Assembly.LoadFrom("selected_math_library.dll");
    var types = assembly.GetTypes();
    
    var mathType = (from type in types
                          where type.GetInterface("IMath") != null && !type.IsAbstract
                          select type).ToList();
    
    if (mathType.Count > 0)
    {
        IMath math = (IMath)Activator.CreateInstance(mathType);
        // call methods from math
    
    }
