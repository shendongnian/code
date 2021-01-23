    var people = new List<Person>
    {
        new Person { FirstName = "John", LastName = "Doe" },
        new Person { FirstName = "Jane", LastName = "Doe" },
        new Person { FirstName = "Bob", LastName = "Saget" },
        new Person { FirstName = "William", LastName = "Drag" },
        new Person { FirstName = "Richard", LastName = "Johnson" },
        new Person { FirstName = "Robert", LastName = "Frost" }
    };
    
    // Method syntax.
    var query = people.Select(p =>
    {
        dynamic exp = new ExpandoObject();
        exp.FirstName = p.FirstName;
        exp.LastName = p.LastName;
        return exp;
    });
    
    // Query syntax.
    var query2 = from p in people
                 select GetExpandoObject(p);
    
    foreach (dynamic person in query2) // query2 or query
    {
        person.FirstName = "Changed";
        Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
    }
    
    // Used with the query syntax.
    private ExpandoObject GetExpandoObject(Person p)
    {
        dynamic exp = new ExpandoObject();
        exp.FirstName = p.FirstName;
        exp.LastName = p.LastName;
        return exp;
    }
