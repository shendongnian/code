    //Add data in inner list
    var lstString = new List<string>();
    Enumerable.Range(1, 10)
      .ToList()
      .ForEach(i => lstString.Add(string.Concat("string", i)));
    
    //Add data in outer list
    List<List<string>> lstStrings = new List<List<string>>();
    Enumerable.Range(1, 5)
      .ToList()
      .ForEach(j => lstStrings.Add(lstString));
                    
    //To fetch data (using lambda)
    lstStrings.ForEach(i => i.ForEach(j => Console.WriteLine(j)));
