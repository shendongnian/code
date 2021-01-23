    var firstSplit = allText.Split(new[]{Environment.NewLine}, 
                                SplitOptions.RemoveEmptyEntries);
    var dataLines = (from i in firstSplit
                     let currLine = i.Split(new[]{" "},SplitOptions.RemoveEmptyEntries)
                     select new 
                     {
                          FirstName = currLine [0],
                          LastName = currLine [1],
                          DateTime = DateTime.ParseExact(currLine[2]+currLine[3],
                                     "MM/dd/yyyy hh.mmtt")
                     }).OrderBy(s=>s.FirstName);
    foreach(var line in dataLines)
        Console.WriteLine("{0} {1} {2}", line.FirstName,
                              line.LastName,
                              line.DateTime.ToString("MM/dd/yyyy hh.mmtt"));
