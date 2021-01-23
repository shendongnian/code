    for (int i = 0; i < methodParameters.Length; i++)
    {
        // I. instead of this
     
        //values.First(x => x.Key == unMappedList.ElementAt(i).Key)
        //    .Key = methodParameters.ElementAt(i).Name; 
        //above doesn't work, but even if it did it wouldn't do the right thing
    
        // II. do this (not so elegant but working;)
        var key = unMappedList.ElementAt(i).Key;
        var value = values[key];
        values.Remove(key);
        values.Add(methodParameters.ElementAt(i).Name, value);
                            
        // III. THIS is essential! if statement must be moved after the for loop
        //return true;
    }
    return true; // here we can return true
