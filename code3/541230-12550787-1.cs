    var lines = File.ReadLines("C:\\input.txt");
    
    var widthList = lines.First().GroupBy(c => c)
                                 .Select(g => g.Count())
                                 .ToList();
    
    var list = new List<KeyValuePair<int, int>>();
    
    int startIndex = 0;
    
    for (int i = 0; i < widthList.Count(); i++)
    {
        var pair = new KeyValuePair<int, int>(startIndex, widthList[i]);
        list.Add(pair);
    
        startIndex += widthList[i];
    }
    
    var csvLines = lines.Select(line => string.Join(",", 
                        list.Select(pair => line.Substring(pair.Key, pair.Value))));
    
    File.WriteAllLines("C:\\test.csv", csvLines);
    
