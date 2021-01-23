    // Get the assembly with Reflection:
    Assembly assembly = typeof(App).GetTypeInfo().Assembly;
    // Get the custom attribute informations:
    var titleAttribute = assembly.CustomAttributes.Where(ca => ca.AttributeType == typeof(AssemblyTitleAttribute)).FirstOrDefault();
    // Now get the string value contained in the constructor:
    return titleAttribute.ConstructorArguments[0].Value.ToString();
