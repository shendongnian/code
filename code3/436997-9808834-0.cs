    string input = "There are 4 numbers in this string 40, 30, and 10";
    var query = Regex.Split(input, @"(,)\s?|\s")
                     .Select(s => new
                     {
                         Value = s,
                         Type = Char.IsLetter(s[0]) ?
                                 "String" : Char.IsDigit(s[0]) ?
                                 "Number" : "Symbol"
                     });
    foreach (var item in query)
    {
        Console.WriteLine("{0} : {1}", item.Value, item.Type);
    }
