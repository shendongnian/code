    var listA = ...;
    var listB = ...;
    
    var itemsToRemove = new HashSet<Data>(listA.Except(listB));
    var itemsToAdd = listB.Except(listA);
    var itemsToUpdate = listA.Join(listB, a => listA.Key, b => listB.Key, 
                (a, b) => new
                {
                    First = a,
                    Second = b
                });
    listA.AddRange(itemsToAdd);
    listA.RemoveAll(item => itemsToRemove.Contains);
    foreach(var pair in itemsToUpdate)
    {
      //set properties in First to be that of second
    }
