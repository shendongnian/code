    var TheData = (from l in MyDC.Table select new { 
        stringLong = l.StringOfLongs,
        OtherProps = //...
    })
      .AsEnumerable()
      .Select(x => new Model 
                       { 
                           TheListOfLongs = x.stringLong 
                                  .Split(',')   
                                  .Select(y => Convert.ToInt64(y)
                                  .Cast<long>(),
                           OtherProps = // ...
                       });
