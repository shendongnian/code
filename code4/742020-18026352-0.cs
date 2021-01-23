     var ownedPetOwnerNames = P.Pets.Where(a => a.IsOwned == true)
                               .Select(a => a.OwnerName).ToList();
    int Count = P.Pets.Where(c => c.CreatedDate >= Date&&
       
      ownedPetOwnerNames.Contains(c.OwnerName)).GroupBy(b=>b.OwnerName).Count();
