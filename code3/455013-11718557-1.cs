    using ExtensionMethods;
    
    ...
    
    List<Person> people = new List<Person>{
                       new Person{ID = 1, FirstName = "Scott", LastName = "Gurthie"},
                       new Person{ID = 2, FirstName = "Bill", LastName = "Gates"}
                       };
    
    
    string jsonString = people.ToJSON();
