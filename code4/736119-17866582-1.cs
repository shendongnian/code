    var firstSplit = allText.Split(new[]{Environment.NewLine}, 
                                SplitOptions.RemoveEmptyEntries)
    var dataLines = (from i in firstSplit
                     let currLine = i.Split(new[]{" "},SplitOptions.RemoveEmptyEntries)
                     select new 
                     {
                          FirstName = currLine [0],
                          LastName = currLine [1],
                          Date = DateTime.ParseExact(currLine[2],"MM/dd/yyyy"),
                          Time = DateTime.ParseExact(currLine[3],"hh.mmtt")
                     }).OrderBy(s=>s.FirstName)
    foreach(var line in dataLines)
        Console.WriteLine("{0} {1} {2} {3}", line.FirstName,
                                              line.LastName,
                              line.Date.ToString("MM/dd/yyyy"),
                                    line.Time.ToString("hh.mmtt"));
