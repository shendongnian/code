    int counter = 0;
    foreach (var pair in DictA)
    {
           int value;
           if (DictB.TryGetValue(pair.Key, out value))
           {
               if (value == pair.Value)
               {
                   counter++;
               }
           }
    }
    
