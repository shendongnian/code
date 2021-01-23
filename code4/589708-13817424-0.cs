    using (ListDataContext syndb = new ListDataContext())
    {
        using (QueryDataContext ledb = new QueryDataContext())
        {
            var stp = syndb.StoredPets.OrderBy(x => x.Name).Select(x => x.PetID).ToList();
            var slp = ledb.SoldPets.ToList().OrderBy(x => stp.IndexOf(x.petId));
            // do something with the query
        }
    }
