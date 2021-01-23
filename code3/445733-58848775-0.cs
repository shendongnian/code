    Console.WriteLine($"int? is {(IsNullable(typeof(int?)) ? "nullable" : "non nullable")} type");
    Console.WriteLine($"int is {(IsNullable(typeof(int)) ? "nullable" : "non-nullable")} type");
    
    bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;
    
    // Output:
    // int? is nullable type
    // int is non-nullable type
