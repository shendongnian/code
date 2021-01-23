    MemoryProtection a = MemoryProtection.ExecuteRead;
    if (MemoryProtection.Readable.HasFlag(a)) {
        Console.WriteLine("Readable");
    }
    if (MemoryProtection.Writable.HasFlag(a)) {
        Console.WriteLine("Writable");
    }
