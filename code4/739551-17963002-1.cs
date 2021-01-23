    IEnumerable<string> numbers
        = taxNumber.ToCharArray()
                   .Distinct()
                   .Select(c => new string(c, taxNumber.Count(t => t == c)));
    foreach (string numberGroup in numbers)
    {
        Console.WriteLine(numberGroup);
    }
