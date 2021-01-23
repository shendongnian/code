    // Lookup is necessary because a person might be in more than one movie.
    var personLookup = new Dictionary<string,Person>();
    foreach (var contractMovie in dataContractMovies)
    {
        var movie = new Movie() { Title = contractMovie.Title };
        foreach (var contractPerson in contractMovie.Cast)
        {
            if (!personLookup.ContainsKey(contractPerson.Name))
            {
                personLookup.Add(contractPerson.Name, new Person() { Name = contractPerson.Name });
            }
            var person = personLookup[contractPerson.Name];
            foreach (var contractCharacter in contractPerson.Characters)
            {
                var character = new Character() { Name = contractCharacter.Name, Person = person, Movie = movie };
                dataContext.Characters.Add(character);
            }
        }
     }
     dataContext.SaveChanges();
