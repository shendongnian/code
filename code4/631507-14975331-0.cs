    var personList = new List<Person> {
        new Person { Age = 20, FirstName = "John", LastName = "Joe" },
        new Person { Age = 20, FirstName = "John", LastName = "Joe" },
        new Person { Age = 10, FirstName = "James", LastName = "Dokes"}};
    var results = personList.GroupBy(per => new { per.Age, per.FirstName, per.LastName },
        (key, items) => new { key.Age, key.FirstName, key.LastName, Count = items.Count() } );
