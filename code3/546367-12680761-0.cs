    string numbers = string.Empty;
    using (var reader = new StreamReader(@"C:\Temp\so.txt"))
    {
        numbers = reader.ReadToEnd();
    }
    
    var matches = numbers.Split(' ').Where(s => s.Length == 1 || s.Length == 2);
    foreach (var match in matches)
    {
        Console.WriteLine(match);
    }
