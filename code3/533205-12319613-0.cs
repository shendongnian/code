    var str = "ID | Col1 | Col2 | Col3 | Col4 | Col5 | Col6 | Col7 | Col8";
    var strA = str.Split(" | ".ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
    strA.RemoveAt(2);
    strA.RemoveAt(3);
    Console.WriteLine(string.Join(" | ", strA.ToArray()));
