    List<StoredPet> storedPets;
    List<SoldPet> soldPets;
    using (ListDataContext listDataContext = new ListDataContext())
    {
        using (QueryDataContext queryDataContext= new QueryDataContext())
        {   
            storedPets =
                listDataContext.StoredPets
                    .OrderBy(sp => sp.Name)
                    .Select(sp => sp.PetId)
                    .ToList();
 
            soldPets =
                queryDataContext.SoldPets
                    .ToList();
        }
    }
    List<SoldPets> orderedSoldPets =
        soldPets.OrderBy(sp => storedPets.IndexOf(sp.PetId))
