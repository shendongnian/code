                        //Group strings without considering case
    bool doesListPass = strings.GroupBy(s => s.ToUpper())
                        //Check that all strings in each group has the same case
                        .All(group => group.All(s => group.First() == s));
    
                        //Group strings without considering case
    IEnumerable<string> cleanedList = strings.GroupBy(s => s.ToUpper())
                        //Check that all strings in each group has the same case
                        .Where(group => group.All(s => group.First() == s))
                        //Map all the "passing" groups to a list of strings 
                        .SelectMany(g => g.ToList());
