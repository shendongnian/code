    var list = line.Split(new[] {".abc_", ".ABC_"}, 
                                  StringSplitOptions.RemoveEmptyEntries);
    if (list.Count() > 1)
    {
        string toReplace = list.First().Split(' ').Last();
        string output = line.Replace(toReplace, "john");
    }
