    private IEnumerable<Type> GetContractType(Type serviceType) 
    { 
        if (HasServiceContract(serviceType))
        { 
            yield return serviceType; 
        } 
        var contractInterfaceTypes = serviceType.GetInterfaces() 
            .Where(i => HasServiceContract(i));
        foreach (var type in contractInterfaceTypes)
        {
            yield return type;
        }
        // if you want, you can also go to the service base class,
        // interface inheritance, etc.
    } 
    private static bool HasServiceContract(Type type) 
    { 
        return Attribute.IsDefined(type, typeof(ServiceContractAttribute), false); 
    }
