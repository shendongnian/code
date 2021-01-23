    foreach(part in Enumerable.Range(0,Parts.Count)
                                .Select(i => Parts.Retrieve(i))
                                .OrderBy(p => p.PartNumber))
    {
            Console.WriteLine("Part #:      {0}", part.PartNumber);
    }
