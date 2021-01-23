    var people = new List<Person>
                 {
                     new Person {Id = 1, Name = "John"},
                     new Person {Name = "Dave", Id = 2},
                     new Person {Id = 3, Name = "Sarah"}
                 };
    var vamps = new List<Vampire> {new Vampire {Id = 1}};
    var theInfected = people.Where(p => vamps.Select(v => v.Id).Contains(p.Id));
    var theAfraid = people.Except(theInfected);
    foreach (var person in theInfected)
       {
           System.Console.WriteLine(person.Name + " Is Infected!");
       }
    foreach (var person in theAfraid)
      {
         System.Console.WriteLine(person.Name + " Is Afraid!");
      }
