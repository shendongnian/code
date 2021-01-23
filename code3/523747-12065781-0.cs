    string inputString = "The black, and, white cat"; 
    var something = inputString.ToCharArray();  
    var txtEntitites = something.GroupBy(c => c)
                                .OrderByDescending(g => g.Count())
                                .Where(e => Char.IsLetter(e.Key))
                                .Select(t=> t.Key);
