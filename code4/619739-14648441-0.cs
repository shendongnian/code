    IEnumerable<IEnumerable<FileResult>> pages = GetPages(query, 1000);
    foreach (IEnumerable<FileResult> page in pages)
    {
        Console.WriteLine("Start of page!");
        foreach (var result in page)
        {
            Console.WriteLine("{0} - {1}", result.FilePath, result.FileName);
        }
        Console.WriteLine("End of page!");
    }
