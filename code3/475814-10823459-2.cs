    var groupedPersons = personList.GroupBy(c => c.City)
        //need an enumerable of enumerables, not an enumerable of groupings, 
        //because the method isn't covariant.
        .Select(group => group.AsEnumerable());
    var results = groupedPersons.CartesianProduct();
    foreach (var group in results)
    {
        foreach (var person in group)
        {
            Console.Write(person.Name + " ");
        }
        System.Console.WriteLine();
    }
