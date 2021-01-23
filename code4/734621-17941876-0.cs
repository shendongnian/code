    Pet[] pets =
        {
            new Pet {Name = "Barley", Age = 8},
            //Using null is fine
            new Pet {Name = null, Age = 1}, 
            new Pet {Name = "Boots", Age = 4}
        };
    // Sort the Pet objects in the array by Pet.Name
    IEnumerable<Pet> query = pets.AsQueryable().OrderBy(pet => pet.Name);
    foreach (Pet pet in query)
        Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
