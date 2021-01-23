    Console.WriteLine("Value type");
    Test(() => IsNullHelper<int>.IsNull(1));
    Console.WriteLine();
    Console.WriteLine("Non-null nullable value type");
    Test(() => IsNullHelper<int?>.IsNull(1));
    Console.WriteLine();
    Console.WriteLine("Null nullable value type");
    Test(() => IsNullHelper<int?>.IsNull(null));
    Console.WriteLine();
    // The object.
    var o = new object();
    Console.WriteLine("Not null reference type.");
    Test(() => IsNullHelper<object>.IsNull(o));
    Console.WriteLine();
    Console.WriteLine("Null reference type.");
    Test(() => IsNullHelper<object>.IsNull(null));
    Console.WriteLine();
