    string searchKeyword = "GSA Search";
    var times = File.ReadAllLines("log.txt")
                    .Where(l => l.Contains(searchKeyword))
                    .Select(ParseElapsedTime)
                    .DefaultIfEmpty() 
                    .ToList();
     var averageTime = times.Average();   // 882,525
     var maxTime = times.Max();           // 890
     var totalTime = times.Sum();         // 3530,1
