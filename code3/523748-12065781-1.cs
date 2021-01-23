    varinputString = "The black, and, white cat"; 
    var txtEntitites = inputString.GroupBy(c => c)
                                  .OrderByDescending(g => g.Count())
                                  .Select(t=> t.Key)
                                  .Where(e => Char.IsLetter(e));
