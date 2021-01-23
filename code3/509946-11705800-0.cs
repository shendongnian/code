    var rnd = new Random();
    var people = new List<Person>();
    for (int i = 0; i < 10; i++)
        people.Add(new Person { Name = rnd.Next().ToString() });
    
    //remember, this provides an alphabetical, not numerical ordering,
    //because name is a string, not numerical in this example.
    people = people.OrderBy(person => person.Name).ToList();
    people.ForEach(person => Console.WriteLine(person.Name));
    Console.ReadLine();
