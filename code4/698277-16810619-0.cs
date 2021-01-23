    string inputFull = "Steve Brian McFistycuffs Johnson";
    string[] stringSeparators = new string[] {" "};
    
    var matches = myContext.MyTable;
    
    foreach(string input in inputFull.Split(stringSeparators, StringSplitOptions.None))
    {
       matches = matches.Where(c => c.Name.Contains("input"))
    }
