    foreach(var group in groups)
    {
        Console.WriteLine("Group " + group.Group);
        Console.WriteLine("Lines:");
        Console.WriteLine(string.Join(", ", group.SelectMany(h => h.InvoiceHeader.InvoiceLines)));
    }
