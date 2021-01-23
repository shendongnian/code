    object[,] o = new object[,]
    {
        {"foo", "bar"},
        {"spam", "eggs"},
    };
    
    string[,] s = new string[o.GetLength(0), o.GetLength(1)];
    Array.Copy(o, s, o.Length);
    
    Console.WriteLine(s[0, 0]); // Prints foo
