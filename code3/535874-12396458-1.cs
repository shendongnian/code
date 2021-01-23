    Console.WriteLine("Value type");
    Test(() => IsNullCast(1));
    Console.WriteLine();
    Console.WriteLine("Non-null nullable value type");
    Test(() => IsNullCast((int?)1));
    Console.WriteLine();
    Console.WriteLine("Null nullable value type");
    Test(() => IsNullCast((int?)null));
    Console.WriteLine();
    // The object.
    var o = new object();
    Console.WriteLine("Not null reference type.");
    Test(() => IsNullCast(o));
    Console.WriteLine();
    // Set to null.
    o = null;
    Console.WriteLine("Not null reference type.");
    Test(() => IsNullCast<object>(null));
    Console.WriteLine();
