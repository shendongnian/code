    var names = new List<string> { "asa", "@!", "~!@#$%^tryt", "asas**)_+lk" };populated at run time
    var unsupportedCharacters = new HashSet<char>("~!#$%^&*");
            
    var newNames = names.Select(n => String.Join("", n.Where(c => !unsupportedCharacters.Contains(c))))
                        .ToList();
