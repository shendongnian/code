    DateTime eightDaysOld = EntityFunctions.AddHours(DateTime.Now, -8);
    
    //calculate these independently from the rest of the query
    var ownedPetOwnerNames = P.Pets.Where(a => a.IsOwned == true)
                                   .Select(a => a.OwnerName);
                                  
                                  //Evaluate the dates first, it should be 
                                  //faster than Contains()
    int Count = P.Pets.Where(c => c.CreatedDate >= eightDaysOld &&
                                  
                                  //Using the cached result should speed this up
                                  ownedPetOwnerNames.Contains(c.OwnerName))
                      .GroupBy(b=>b.OwnerName).Count();
