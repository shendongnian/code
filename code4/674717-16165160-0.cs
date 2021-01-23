    var newDictionary = dic.Select(x => new 
                {
                   Key = x.Key,
                   Value = x.Value.Select( y => 
                          {
                              depCountry = y.ComponentValue("Dep")
                          }).FirstOrDefault()
                 }
                 .Where(x => x.Value != null)
                 .ToDictionary(x => x.Key, x => x.Value());
