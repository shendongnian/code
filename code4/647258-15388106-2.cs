    toRemove = machine.Array
                  .Select(x => 
                      new KeyValuePair<int, string>((int)x.MachineID, x.PackageID))
                  .ToList();
    // create a hash set and initially put all the elements from toRemove in the set
    var r = new HashSet<KeyValuePair<int, string>>(toRemove);
    // go over each element in the clickedList
    //    and check whether it actually needs to be removed
    foreach(var kvp in clickedList.Keys)      // O(n);  n = # of keys/elem. in dictionary
    {
        if(kvp.Value == OperationType.Remove)
        {
           if(r.Contains(kvp.Key)             // O(1)
              r.Remove(kvp.Key);              //    (1)
           else
              r.Add(kvp.Key);                 //   O(1)
        }
    }
    foreach(var key in r)                     // O(m); m = # of keys to be removed 
    {
        clickedList.Remove(key);
    }
