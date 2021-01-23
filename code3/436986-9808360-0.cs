    foreach(int outerKey in outerDictionary.Keys)
       {
          Dictionary<int, List<int>> outerValue = outerDictionary[outerKey];
 
          foreach(int innerKey in outerValue.Keys)
          {
              List<int> innerValue = outerValue[innerKey];
              foreach(int item in innerValue)
              {
                 // do something with item
              }
          }
       } 
