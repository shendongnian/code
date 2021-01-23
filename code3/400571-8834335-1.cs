    IEnumerable<string> stringSource = File.ReadLines("C:\\file.txt");
    
    var result = stringSource
        .GroupBy(str => str)
        .Select(group => new {Value = group.Key, Count = group.Count()})
        .OrderBy(item => item.Count)
        .ToList();
    
    foreach(var item in result)
    {
        // item.Value - string value
        // item.Count - count
    }
