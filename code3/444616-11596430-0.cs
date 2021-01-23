    using (var context = new MyContext())
    {
        var person = new Person
        {
            CurrentLocationId = 1,
            CurrentLocation = new Location { Id = 2 }
        };
        context.People.Attach(person); // Exception
    }
