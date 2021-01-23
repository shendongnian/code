    Person[] names = { new Person { Name = "Murugan", Money = 15000 },
                       new Person{Name="Vel",Money=17000},
                       new Person{Name="Murugan",Money=1000},
                       new Person{Name="Subramani",Money=18000},
                       new Person{Name="Vel",Money=2500} };
    
    var result = (from val in names
                  where val.Name == "Murugan"
                  select val).ToList();
    
    Console.WriteLine(result.Count);
    Console.ReadLine();
