    object[,] src = new object[,]
    {
        {"foo", "bar"},
        {"spam", "eggs"},
    };
    
    string[,] dest = new string[o.GetLength(0), o.GetLength(1)];
    Array.Copy(src, dest, src.Length);
