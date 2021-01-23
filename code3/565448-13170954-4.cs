    SortedList<string, Person> list = 
              new SortedList<string, Person> (StringComparer.CurrentCulture);
    Person person = new Person { Name = "aby", Age = "1" };
    list.Add(person.Name, person);
    person = new Person { Name = "aab", Age = "2" };
    list.Add(person.Name, person);
   
    foreach (Person p in list.Values)
        Console.WriteLine(p.Name);
