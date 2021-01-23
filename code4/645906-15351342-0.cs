    var list = new List<string>
    {
       "String 1",
       "String 17",
       "String 2",
       "String 15",
       "String 3gg"
    };
    var sort = list.OrderBy(s => int.Parse(new string(s.SkipWhile(c => !char.IsNumber(c)).TakeWhile(c => char.IsNumber(c)).ToArray())));
