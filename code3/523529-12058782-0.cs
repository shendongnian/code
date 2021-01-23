    Type t = typeof (Nullable<DateTime>);
    
    Console.WriteLine(t.Name);   // Nullable`1
    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
    {
        Type t2 = Nullable.GetUnderlyingType(t);
        Console.WriteLine("Nullable"+t2.Name); // NullableDateTime
    }
