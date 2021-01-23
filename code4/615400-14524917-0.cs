    PetOwner[] petOwners = 
                        { new PetOwner { Name="Higa, Sidney", 
                              Pets = new List<string>{ "Scruffy", "Sam" } },
                          new PetOwner { Name="Ashkenazi, Ronen", 
                              Pets = new List<string>{ "Walker", "Sugar" } },
                          new PetOwner { Name="Price, Vernette", 
                              Pets = new List<string>{ "Scratches", "Diesel" } } };
    
                    // Query using SelectMany().
                    IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);
