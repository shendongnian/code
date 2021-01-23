    List<int?> values = new List<int?>();
    var test = values.FirstOrDefault();
    if (test == null)
        Console.WriteLine("Null!");
    if (test.HasValue)
        Console.WriteLine(test.Value);
    else
        Console.WriteLine("No Value but no NullReferenceException");
    try
    {
        int value = test.Value;
    }
    catch(InvalidOperationException)
    {
        Console.WriteLine("Oops, InvalidOperationException");
    }
