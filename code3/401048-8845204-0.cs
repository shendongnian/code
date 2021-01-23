    Type type = Type.GetType(typeName, true);
    if (!type.IsEnum)
        throw new ArgumentException(typeName + " is not an enum.");
    Console.WriteLine("UnderlingType: {0}", type.UnderlyingSystemType);
    string description = string.Empty;
    foreach ( var thing in Enum.GetValues((type.UnderlyingSystemType)))
    {
        ...
    }
