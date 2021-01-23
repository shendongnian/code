    List<sik> input = new List<sik>();
    for (int i = 0; i < 5; i ++)
    {
        var newInput = new sik();        
        newInput .skId = securitiesArray[i].skId;
        newInput .country = securitiesArray[i].country;
        input.Add(newInput);
    }
