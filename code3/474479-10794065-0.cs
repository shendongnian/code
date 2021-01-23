    var animals = new List<Animal>();
    // get some animals...
    var animalictionary = animals.ToDictionary(a => a.Age);
    // assuming the animals have distinct ages, else
    var animalLookup = animals.ToLookup(a => a.Age);
    foreach (var animalGroup in animalLookup)
    {
        var age = animalGroup.Key;
        Console.WriteLine("All these animals are " + age);
        foreach (Animal animal in animalGroup)
        {
            Console.WriteLine(animal.name);
        }
    } 
