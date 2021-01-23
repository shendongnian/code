    var stringList = new[] { "abc   xyz 123   456", "cba 1234a 45623 say", "avc  4567 bv    456" };
    var shortest = stringList.OrderBy(s => s.Length).First();
    var result = new Collection<int>();
    for (int i = 0; i < shortest.Length; i++)
    {
        if (stringList.All(c => c[i] == ' ')) result.Add(i+1);
    }
    // Test the results
    foreach (var index in result)
    {
        Console.WriteLine(index);
    }
