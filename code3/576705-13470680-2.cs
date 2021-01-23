    while (HaveToContinue)
    {
       // Do work 1
       Dictionary<Key,Value> localDictionary;
       lock (sync)
       {
          localDictionary = new Dictionary<Key,Value>(myDictionary);
       }
       
       foreach (var item in localDictionary)
       {
          // Do something with/to item
       }
       // Do work 2 (I need to complete the foreach first)
    }
