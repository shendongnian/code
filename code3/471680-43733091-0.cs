    Assembly assembly = Assembly.LoadFrom("pathToDLL");
    foreach (Type type in assembly.GetTypes())
    {
        foreach (MethodInfo methodInfo in type.GetMethods())
        {
            var attributes = methodInfo.GetCustomAttributes(true);
            foreach (var attr in attributes)
            {
                if (attr.ToString() == "NUnit.Framework.TestAttribute")
                {
                   var methodName = methodInfo.Name;
                    // Do stuff.
                }
            }
        }
    }
