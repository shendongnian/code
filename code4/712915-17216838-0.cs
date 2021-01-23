    string input = "new Date(2012,9,3)";
    var dateTimeString = input.Split(new[] {'(', ')'}, 
                                     StringSplitOptions.RemoveEmptyEntries)
                              .Last();
    var datetime = DateTime.ParseExact(dateTimeString, 
                                       "yyyy,M,d", CultureInfo.InvariantCulture);
