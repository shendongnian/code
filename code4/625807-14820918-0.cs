    var TheData = (from l in MyDC.Table select new { 
        stringLong = l.StringOfLongs,
        OtherProps = //...
    })
      .ToList()
      .Select(x => new Model 
                       { 
                           TheListOfLongs = x.stringLong
                                             .Split(',')
                                             .Convert.ToInt64(x)
                                             .Cast<long>(),
                           OtherProps = // ...
                       });
