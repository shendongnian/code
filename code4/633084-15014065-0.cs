    MemberInfo member;      // <-- Get a member
    
    var customAttributes = member.GetCustomAttributesData();
    foreach (var data in customAttributes)
    {
        // The type of the attribute,
        // e.g. "SomeCustomAttribute"
        Console.WriteLine(data.AttributeType);
        
        foreach (var arg in data.ConstructorArguments)
        {
            // The type and value of the constructor arguments,
            // e.g. "System.String a supplied value"
            Console.WriteLine(arg.ArgumentType + " " + arg.Value);
        }
    }
    
