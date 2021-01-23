    string inputString = "The black, and, white cat";
    var something = inputString.ToCharArray();
    var txtEntitites = something.Where(e => Char.IsLetter(e))
                       .GroupBy(c => c)
                       .OrderByDescending(g => g.Count()).Select(t=> t.Key);
