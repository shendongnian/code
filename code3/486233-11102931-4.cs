    var results = xdoc.Descendants("detail")
                      .Select( x => new 
                       {
                           Code = x.Element("code").Value,
                           Amount = x.Element("subDetail")
                                     .Element("amount").Value 
                       });
    foreach (var item in results)
    {
        Console.WriteLine("Code = {0}, Amount = {1}", item.Code, item.Amount);
    }
