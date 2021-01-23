    // We will use these things:
    Predicate<Person> yourPredicate = p => p.FirstName == "Bob";
    Func<Person, bool> yourPredicateFunction = p => p.FirstName == "Bob";
    Person specificPerson = people[0];
    
    // Checking existence of someone:
    bool test = people.Contains(specificPerson);
    bool anyBobExistsHere = people.Exists(yourPredicate);
    
    // Accessing to a person/people:
    IEnumerable<Person> allBobs = people.Where(yourPredicateFunction);
    Person firstBob = people.Find(yourPredicate);
    Person lastBob = people.FindLast(yourPredicate);
    
    // Finding index of a person
    int indexOfFirstBob = people.FindIndex(yourPredicate);
    int indexOfLastBob = people.FindLastIndex(yourPredicate);
