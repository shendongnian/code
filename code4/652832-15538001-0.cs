    string pattern = "<your pattern here>";
    static IEnumerable<string> GetData()
       {
           var strList = new List<string> 
           { "I'm in love",
            "Coffee contains caffeine",
            "The best inn so far",
            "Inside of me",
            "in the darkness"};
           var filteredItems = strList.Where(x => Regex.IsMatch(x, pattern));
           return filteredItems;
       }
