    toRemove = machine.Array
                  .Select(x => 
                      new KeyValuePair<int, string>((int)x.MachineID, x.PackageID))
                  .ToList();
    // create a hash set and initially put all the elements from toRemove in the set
    var r = new HashSet<KeyValuePair<int, string>>(toRemove);
    // go over each element in the clickedList
    //    and check whether it actually needs to be removed
    foreach(var kvp in clickedList.Keys)
    {
        if(kvp.Value == OperationType.Remove)         // if "Remove" operation
           r.Add(kvp.Key);                            //    add to set        
    }
    foreach(var key in r)
    {
        clickedList.Remove(key);
    }
