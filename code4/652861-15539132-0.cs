    PropertyInfo[] props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (PropertyInfo prop in props)
    {
        Console.WriteLine("Property: " + prop.Name);
        foreach (CustomAttributeData att in prop.CustomAttributes)
        {
            Console.WriteLine("\tAttribute: " + att.AttributeType.Name);
            foreach (CustomAttributeTypedArgument arg in att.ConstructorArguments)
            {
                Console.WriteLine("\t\t" + arg.ArgumentType.Name + ": " + arg.Value);
            }
        }
    }
