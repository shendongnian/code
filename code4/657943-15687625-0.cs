    db.Pets.Select(p => new 
    { 
        Id = p.ID, 
        .... other pet properties you want, 
        Veterinarian = new 
        { 
            ID = p.Veterinarian.ID 
            ... other veterinarian properties you want
        },
        Client = 
        {
            ... client properties you need.
        }
    });
