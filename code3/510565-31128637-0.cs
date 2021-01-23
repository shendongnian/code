    var people = new List<Person> { 
        new Person { FirstName = "Aaa", LastName = "BBB", Age = 2 },
        new Person{ FirstName = "Deé", LastName = "ève", Age = 3 }
    };
    people = people.ConvertAll(m => new Person 
             {
                 FirstName = m.FirstName.ToUpper(), 
                 LastName = m.LastName.ToUpper(), 
                 Age = m.Age
             });
