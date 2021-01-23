    var dict = new Dictionary<string, List<string>>();
    
    foreach(var listItem in inputclass)
    {
       foreach(var metaItem in metadata)
       {
           try
           {
                var value = ReflectionExt.GetAttr(listItem, metaItem);
    
                if (dict[metaItem] == null)
                    dict[metaItem] = new List<string>();
    
                if (!dict[metaItem].Contains(value)) // Add only if not exists
                    dict[metaItem].Add(value);
           }
           catch
           {
               ;
           }
    
       }
    
    }
