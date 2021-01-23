    Console.WriteLine(string.Join(",", l1Result.Select(i => !i.HasValue ? "NULL" : i.Value.ToString())));
    Console.WriteLine(string.Join(",", l2Result.Select(i => !i.HasValue ? "NULL" : i.Value.ToString())));
    Console.WriteLine(string.Join(",", l3Result.Select(i => !i.HasValue ? "NULL" : i.Value.ToString())));
    1,      2,      3,      4,      NULL,   NULL,   NULL,   NULL
    NULL,   2,      3,      NULL,   5,      6,      7,      8
    NULL,   NULL,   3,      4,      5,      NULL,   NULL,   NULL
