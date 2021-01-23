    List<String> lines = new List<string>()
         { 
             "a bag of coins",
             "a siog brandy",
             "a bag of coins",
             "a bag of coins",
             "the Cath Shield",
             "a tattered scroll"
         };
    var lineCountDict = lines.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    foreach (var val in lineCountDict)
    {
         Console.WriteLine(val.Key + " - " + val.Value);
    }
