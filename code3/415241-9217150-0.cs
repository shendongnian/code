    List<Person> people = new List<Person>();
    Person p1 = new Person(74, "Brad","Millington","Program Manager", "Milford");
    Person p2 = new Person(58, "John", "Kaufman", "Author", "Ottawa");
    Person p3 = new Person(68, "-*", "Washington" , "Developer", "Redmond");
    Person p4 = new Person(79, "Abraham", "Licoln", "Developer", "Redmond");
    people.Add(p1);
    people.Add(p2);
    people.Add(p3);
    people.Add(p4);
    foreach (Person p in people)
    {
        Console.WriteLine(p.FirstName + " " + p.LastName);
    }
