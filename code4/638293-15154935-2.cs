    var b = BitConvertor.GetBytes(val);
    Console.Write('[')
    for (var i = 0; i < b.Length - 1; i++)
    {
        Console.Write(b[i]);
        Console.Write(", ");
    }
    Console.Write(b[b.Length - 1]);
    Console.WriteLine(']');
