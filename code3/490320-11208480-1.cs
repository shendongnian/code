    Dictionary<int, string> DicA = new Dictionary<int, string>();
    DicA.Add(1,"Mango");
    DicA.Add(2,"Grapes");
    DicA.Add(3,"Orange");
    
    Dictionary<int, string> DicB = new Dictionary<int, string>();
    DicB.Add(1,"Mango");
    DicB.Add(2,"Pineapple");
    
    int counter = 0;
               
    foreach (var pair in DicA)
    {
         string value;
                        
         if (DicB.TryGetValue(pair.Key, out value))
         {
              if (value == pair.Value)
              {
                    counter++;
              }
         }
    }
