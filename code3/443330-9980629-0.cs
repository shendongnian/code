    bool IsItNull<T>(T value)
    {
        return value == null;
    }
    Console.WriteLine(IsItNull(new object())); // False
    Console.WriteLine((string)null); // True
    Console.WriteLine(5); // False
