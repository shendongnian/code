        string newName = "new name";
        int[] numbers = new int[] { 1, 2, 3 };
        var people = numbers.Select(n => new Person()
        {
            Name = n.ToString()
        }).ToList(); // <===== here
            
        foreach (var person in people)
        {
            person.Name = newName;
        }
        var b = people.First().Name == newName;
