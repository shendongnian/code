    var reader = new PdfReader(@"icpc_briefing_1_sep_10.pdf");
    Console.WriteLine("Number of pages: {0}", reader.NumberOfPages);
    
    Console.WriteLine();
    Console.WriteLine("=== INFO ===");
    foreach (var pair in reader.Info)
    {
        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
    }
    
    var meta = reader.Metadata;
    if (meta != null)
    {
        Console.WriteLine();
        Console.WriteLine("=== XMP ===");
        Console.Write(Encoding.UTF8.GetString(meta));
        Console.WriteLine();
    }
