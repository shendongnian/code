    var al = new StateProvince { Abbreviation = "AL", Name = "Alabama" },
    var ak = new StateProvince { Abbreviation = "AK", Name = "Alaska" },
    var ar = new StateProvince { Abbreviation = "AZ", Name = "Arizona" },
    
    context.StateProvinces.AddOrUpdate(
        p => p.Abbreviation,
        al,
        ak,
        ar
    );
    
    context.SaveChanges();
    
    context.Counties.Add(new County() { Name = "Something", StateProvince = al });
    
    // DONT CALL SAVE, Initializer needs something to do or it complains
