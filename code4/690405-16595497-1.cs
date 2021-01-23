    List<Person> persons = new List<Person>{
            new Person(){
            Id = 1,
            Name = "sadsad",
            Surname = new List<string>(){"Examle"}
            },
    
            new Person(){
            Id = 2,
            Name = "fbs",
            Surname = new List<string>(){"ggg"}
            }};
    // adding another person
    persons.Add(new Person() { Id = 3, Name = "cc", Surname = new List<string>() { "ggg" } });
