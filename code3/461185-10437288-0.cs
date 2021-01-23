    Assembly testAssembly = Assembly.LoadFile(<path>);
    var interfaceType = testAssembly.GetTypes().Where(x => x.Name == "ISampleInterface").FirstOrDefault();
    if(interfaceType != null)
    {
        var implementingType = testAssembly.GetTypes().Where(typ => type.GetInterfaces().Any(iface => iface == interfaceType)).FirstOrDefault();
        if(implementingType != null)
        {
            dynamic obj = Activator.CreateInstance(implementingType);
            dynamic result = obj.SampleInterfaceMethod();
            Console.WriteLine(result);
        }
    }
