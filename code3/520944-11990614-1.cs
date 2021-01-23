    var listA = ...;
    var listB = ...;
    
    var itemsToRemove = listA.Except(listB);
    var itemsToAdd = listB.Except(listA);
    var itemsToUpdate = listA.Join(listB, a => listA.Key, b => listB.Key, 
                (a, b) => new
                {
                    First = a,
                    Second = b
                });
    listA.AddRange(itemsToAdd);
    listA.RemoveRange(itemsToRemove);
    foreach(var pair in itemsToUpdate)
    {
      //set properties in First to be that of second
    }
