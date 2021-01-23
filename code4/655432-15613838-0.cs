    using System.Linq;
    // later in your program...
    foreach (string match in RFD.Where(l => l.StartsWith("0128"))) {
        Console.WriteLine(match);
    }
